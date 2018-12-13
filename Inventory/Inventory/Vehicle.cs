using System;
using System.Collections.Generic;
using System.Text;

namespace Inventory
{
    public class Vehicle: Product
    {
        public DateTime ExpirationTime { get; set; }
        public decimal Distance { get; set; }
        public Manufacturer Manufact { get; set; }
    }

    public enum Manufacturer
    {
        Toyota = 1,
        Bmw = 2,
        Mercedes = 3,
        Opel = 4,
        Fiat = 5
    }
}
