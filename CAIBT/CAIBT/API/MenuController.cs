using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CAIBT.Data;
using CAIBT.Models;

namespace CAIBT.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MenuController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult GetMenu()
        {
            var menuItems = _context.Products.OrderBy(p => p.Name).ToList();
            return new JsonResult(menuItems);
        }

        [Route("FilteredMenu")]
        public IActionResult FilteredMenu(string Name)
        {
            var menuItem = _context.Products.Where(p => p.Name.Contains(Name)).OrderBy(p => p.Name).ToList();
            return new JsonResult(menuItem);
        }

        [HttpPost]
        public IActionResult PostMenu(string Name, decimal Price, string Description, string ImageUrl, int CategoryId)
        {
            if (string.IsNullOrEmpty(Name))
                return new JsonResult("Name cannot be empty");
            if (Price <= 0)
                return new JsonResult("Price must be greater than 0");
            if (string.IsNullOrEmpty(Description))
                return new JsonResult("Description cannot be empty");
            if (CategoryId <= 0)
                return new JsonResult("Please enter a valid category");

            Product product = new Product();
            product.Name = Name;
            product.Price = Price;
            product.Description = Description;
            product.CategoryId = CategoryId;

            _context.Add(product);
            _context.SaveChanges();

            return new JsonResult(product);

        }

        [HttpDelete("{id}")]
        public IActionResult DeleteMenuItem(int id)
        {
            var product = _context.Products.Find(id);

            if(product == null)
            {
                return NotFound();
            }

            _context.Products.Remove(product);

            _context.SaveChanges();

            return NoContent();
        }

        [HttpPut("{id}")]
        public IActionResult PutMenuItem(int Id, Product product)
        {
            if(Id != product.Id)
            {
                return BadRequest();
            }

            _context.Entry(product).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

            try
            {
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }

            return new JsonResult("No implemented");
        }

    }
}