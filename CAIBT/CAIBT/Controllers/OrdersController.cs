using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CAIBT.Data;
using CAIBT.Models;
using Microsoft.AspNetCore.Authorization;

namespace CAIBT.Controllers
{
    [Authorize]
    public class OrdersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public OrdersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Orders
        public async Task<IActionResult> Index()
        {
            if(User.IsInRole("Admin"))
            {
                return View(await _context.Orders.OrderByDescending(o => o.OrderDate).ToListAsync());
            }
            else
            {
                return View(await _context.Orders
                                    .Where(o => o.CostumerId == User.Identity.Name)
                                    .OrderByDescending(o => o.OrderDate)
                                    .ToListAsync());
            }

        }

        // GET: Orders/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _context.Orders
                .Include( o => o.OrderDetails)
                .ThenInclude( o => o.Product)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        

        private bool OrderExists(int id)
        {
            return _context.Orders.Any(e => e.Id == id);
        }
    }
}
