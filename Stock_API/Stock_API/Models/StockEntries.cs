using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Stock_API.Models
{
    public class StockEntries
    {
        public int Id { get; set; }


        [DisplayFormat(DataFormatString = "{0:c}")]
        public DateTime EntryDate { get; set; }

        [DisplayFormat(DataFormatString = "{0:c}")]
        public decimal DayPriceOpen { get; set; }

        [DisplayFormat(DataFormatString = "{0:c}")]
        public decimal DayPriceClose { get; set; }

        [DisplayFormat(DataFormatString = "{0:c}")]
        public decimal MaxPriceSpan { get; set; }

        [DisplayFormat(DataFormatString = "{0:c}")]
        public decimal MinPriceSpan { get; set; }

        [DisplayFormat(DataFormatString = "{0:c}")]
        public decimal SpanPriceOpen { get; set; }

        [DisplayFormat(DataFormatString = "{0:c}")]
        public decimal SpanPriceClose { get; set; }

        public int Volume { get; set; }

        public double ChangePercentage { get; set; }

        public int StockId { get; set; }
        public Stock Stock { get; set; }
    }
}
