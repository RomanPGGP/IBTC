using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Stock_API.Data;
using System.Collections;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Stock_API.API
{
    [Route("api/[controller]")]
    public class StockController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StockController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult GetStocks()
        {
            var stcks = _context.Stocks.OrderBy(s => s.Symbol).ToList();
            return new JsonResult(stcks);
        }

        [Route("Volume")]
        public IActionResult GetByVolume()
        {
            var stcks = _context.StockEntries.OrderByDescending(s => s.Volume).ToList();
            
            return new JsonResult(stcks);
        }

        [HttpGet("{Id}")]
        public IActionResult SearchStock(int Id)
        {
            var sk = _context.StockEntries.Where(s => s.StockId == Id).ToList();

            return new JsonResult(sk);
        }

        [Route("VolSearch/{Vol?}")]
        public IActionResult SeachVolume(int Vol)
        {
            var sk = _context.StockEntries.Where(s => s.Volume == Vol).ToList();
            return new JsonResult(sk);
        }

        
    }
}
