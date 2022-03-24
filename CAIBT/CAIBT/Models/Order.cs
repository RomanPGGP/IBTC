using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CAIBT.Models
{
    public class Order
    {
        public int Id { get; set; }

        public DateTime OrderDate { get; set; }

        public string DeliveryNotes { get; set; }

        public decimal Total { get; set; }

        public string CostumerId { get; set; }

        public List<OrderDetails> OrderDetails { get; set; }
    }
}
