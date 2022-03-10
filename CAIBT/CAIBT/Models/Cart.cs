using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CAIBT.Models
{
    public class Cart
    {
        public int Id { get; set; }

        public DateTime DateCreated { get; set; }

        public decimal Price { get; set; }

        public int Quantity { get; set; }

        public int ProductId { get; set; }

        public Product Product { get; set; }

        public string CostumerId { get; set; }


    }
}
