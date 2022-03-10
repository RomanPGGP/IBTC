using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CAIBT.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using CAIBT.Models;

namespace CAIBT.Controllers
{
    public class StoreController : Controller
    {
        private readonly ApplicationDbContext _contex;

        public StoreController(ApplicationDbContext context)
        {
            _contex = context;
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

    }
}
