using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyApp.Models
{
    public class Order
    {
        public int ID { get; set; }
        public int ProducId { get; set; }

        public DateTime OrderTime { get; set; } 

        public decimal Quantity { get; set; }

    }
}