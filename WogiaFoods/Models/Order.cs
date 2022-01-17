using System;
using System.Collections.Generic;
using System.Text;

namespace WogiaFoods.Models
{
    public class Order
    {
        public string OrderId { get; set; }
        public string UserName { get; set; }
        public decimal TotalCost { get; set; }
    }
}
