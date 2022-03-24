using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CAIBT.Data;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CAIBT.API
{
    [Route("api/[controller]")]
    public class OrdersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public OrdersController(ApplicationDbContext context)
        {
            _context = context;
        }
        
        [Route("Orders90Days")]
        public IActionResult GetOrders90Days()
        {
            var orders = _context.Orders
                        .Where(o => o.OrderDate >= System.DateTime.Now.AddDays(-90))
                        .OrderBy(o => o.OrderDate);

            return new JsonResult(orders);
        }
    }
}
