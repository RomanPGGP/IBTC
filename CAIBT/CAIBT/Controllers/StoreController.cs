using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CAIBT.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using CAIBT.Models;
using Microsoft.Extensions.Configuration;
using CAIBT.Extensions;
using Stripe;using Stripe.Checkout;



namespace CAIBT.Controllers
{
    public class StoreController : Controller
    {
        private readonly ApplicationDbContext _contex;
        private readonly IConfiguration _configuration;

        public StoreController(ApplicationDbContext context, IConfiguration configuration)
        {
            _contex = context;
            _configuration = configuration;
        }

        // Handles /Store/Index or /Store > Shows a list of categories
        public IActionResult Index()
        {

            var categoryList = _contex.Categories.OrderBy(c => c.Name).ToList();
            return View(categoryList); // returns /views/store/index.cshtml
        }

        // Handles /Store/Browse > Shows a list of menu items filtered by category
        public IActionResult Browse(int id)
        {

            var menuItems = _contex.Products.Where(p => p.CategoryId == id)
                            .OrderBy(p => p.Name)
                            .ToList();

            return View(menuItems); // returns /views/store/browse.cshtml
        }

        // Handle /Store/Details > Shows details of a menu item
        public IActionResult Details()
        {
            return View(); // return /views/store/details.cshtml
        }

        [Authorize]
        public IActionResult Cart()
        {
            string costumerId = User.Identity.Name;

            var cart = _contex.Carts
                        .Include(c => c.Product)
                        .Where(c => c.CostumerId == costumerId)
                        .ToList();

            var total = cart.Sum(c => c.Price);
            ViewBag.TotalAmount = total.ToString();

            return View(cart);
        }

        [Authorize]
        public IActionResult AddToCart(int ProductId, int Quantity)
        {
            var price = _contex.Products.Find(ProductId).Price;

            var costumerId = User.Identity.Name;

            var cart = new Cart();
            cart.ProductId = ProductId;
            cart.Quantity = Quantity;
            cart.Price = price * Quantity;
            cart.DateCreated = System.DateTime.UtcNow;
            cart.CostumerId = costumerId;

            _contex.Carts.Add(cart);
            _contex.SaveChanges();

            return Redirect("Cart");
        }

        [Authorize]
        public IActionResult RemoveFromCart(int id)
        {
            var cartItem = _contex.Carts.Where(c => c.Id == id).FirstOrDefault();

            if(cartItem != null)
            {
                _contex.Carts.Remove(cartItem);
                _contex.SaveChanges();

            }

            return RedirectToAction("Cart");
        }

        [Authorize]
        public IActionResult Checkout()
        {
            var costumerId = User.Identity.Name;
            Models.Order tempOrder = new Models.Order();
            var carItems = _contex.Carts.Where(c => c.CostumerId == costumerId).ToList();
            tempOrder.Total = carItems.Sum(c => c.Price);


            return View(tempOrder);
        }

        [Authorize]
        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult Checkout([Bind("DeliveryNotes")] Models.Order order)
        {
            var costumerId = User.Identity.Name;
            var carItems = _contex.Carts.Where(c => c.CostumerId == costumerId).ToList();
            order.Total = carItems.Sum(c => c.Price);
            order.OrderDate = System.DateTime.UtcNow;
            order.CostumerId = costumerId;

            HttpContext.Session.SetObject("Order", order);

            return RedirectToAction("Payment");
        }

        [Authorize]
        public IActionResult Payment()
        {
            var order = HttpContext.Session.GetObject<Models.Order>("Order");

            ViewBag.Total = order.Total * 100;

            ViewBag.PublishableKey = _configuration["Stripe:PublishableKey"];

            return View();
        }

        [Authorize]
        [HttpPost]
        public IActionResult Payment(string StripeToken)
        {
            var order = HttpContext.Session.GetObject<Models.Order>("Order");

            StripeConfiguration.ApiKey = _configuration["Stripe:SecretKey"];

            var options = new SessionCreateOptions
            {
                PaymentMethodTypes = new List<string> { "card" },
                LineItems = new List<SessionLineItemOptions>
                {
                    new SessionLineItemOptions
                    {
                        PriceData = new SessionLineItemPriceDataOptions
                        {
                            UnitAmount = (long?)(order.Total * 100), // amount in cents
                            Currency = "cad",
                            ProductData = new SessionLineItemPriceDataProductDataOptions
                            {
                                Name = "RomansShop Purchase"
                            }
                        },
                        Quantity =1
                    }
                },
                Mode = "payment",
                SuccessUrl = $"https://{Request.Host}/Store/SaveOrder",
                CancelUrl = $"https://{Request.Host}/Store/Cart"
            };


            var service = new SessionService();

            Session session = service.Create(options);

            return Json(new { id = session.Id });

        }

        [Authorize]
        public IActionResult SaveOrder()
        {
            var order = HttpContext.Session.GetObject<Models.Order>("Order");

            _contex.Orders.Add(order);
            _contex.SaveChanges();

            var costumerId = User.Identity.Name;
            var carItems = _contex.Carts.Where(c => c.CostumerId == costumerId).ToList();

            foreach(var cartItem in carItems)
            {
                var orderDetail = new OrderDetails();
                orderDetail.OrderId = order.Id;
                orderDetail.ProductId = cartItem.ProductId;
                orderDetail.Quantity = cartItem.Quantity;
                orderDetail.Price = cartItem.Price;

                _contex.OrderDetails.Add(orderDetail);
                _contex.SaveChanges();

                _contex.Carts.Remove(cartItem);
                _contex.SaveChanges();
            }

            return RedirectToAction("Details", "Orders", new { @id = order.Id });
        }
    }
}
