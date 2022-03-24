using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Stock_API.Models
{
    public class Stock
    {
        public int Id { get; set; }

        public string Symbol { get; set; }

        public string Company { get; set; }

        public List<StockEntries> StockEntries { get; set; }
    }
}
