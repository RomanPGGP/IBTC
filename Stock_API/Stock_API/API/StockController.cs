using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Stock_API.Data;
using System.Collections;
using Stock_API.Models;
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

        [HttpPost]
        public IActionResult AddStockSymbol(string Company, string Symbol, List<StockEntries> stockEntries)
        {
            if(string.IsNullOrEmpty(Symbol))
                return new JsonResult("Symbol needed");

            if (string.IsNullOrEmpty(Company))
                return new JsonResult("Company needed");

            Stock st = new Stock();
            st.Symbol = Symbol;
            st.Company = Company;
            st.StockEntries = stockEntries;

            _context.Add(st);
            _context.SaveChanges();

            return new JsonResult("Success");
        }

        [HttpPut("{Id}")]
        public IActionResult ModifySymbol(int Id, Stock st)
        {
            if (Id != st.Id)
            {
                return BadRequest();
            }

            _context.Entry(st).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

            try
            {
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }

            return new JsonResult("Success");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteStudent(int id)
        {
            var product = _context.Stocks.Find(id);

            if (product == null)
            {
                return NotFound();
            }

            _context.Stocks.Remove(product);

            _context.SaveChanges();

            return new JsonResult("Success");
        }
    }
}
