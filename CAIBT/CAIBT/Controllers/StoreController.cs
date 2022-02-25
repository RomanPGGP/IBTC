using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CAIBT.Data;
using Microsoft.AspNetCore.Mvc;

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
    }
}
