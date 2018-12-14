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
        public DateTime GuarantyMonths { get; set; }
        public decimal Price { get; set; }
        public decimal CurrentValue { get; set; }
    }


}
