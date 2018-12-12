using System;
using System.Collections.Generic;
using System.Text;

namespace Inventory
{
    public class Product
    {
        public Guid SerialNumber { get; set; }
        public string Description { get; set; }
        public DateTime DateOfBuy { get; set; }
        public TimeSpan GuarantyMonths { get; set; }
        public double Price { get; set; }
        public string Manufacturer { get; set; }
    }
}
