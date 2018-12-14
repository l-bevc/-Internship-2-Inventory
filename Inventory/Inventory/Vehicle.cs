using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Inventory
{
    public class Vehicle: Product
    {
        
        public DateTime ExpirationTime { get; set; }
        public decimal Distance { get; set; }
        public Manufacturer Manufact { get; set; }
        
        public void ValueVehicle()
        {
            CurrentValue = Price;
            var change = Math.Truncate((Distance/20000));
            var minPrice = 20 * Price / 100;
            for (var i = 0; i < change; i++)
            {
                if (CurrentValue > minPrice)
                {
                    CurrentValue = 90 * CurrentValue / 100;
                }
                else
                {
                    CurrentValue = minPrice;
                    break;
                }
            }      
        }
    }
}

    public enum Manufacturer
    {
        Toyota = 1,
        Bmw = 2,
        Mercedes = 3,
        Opel = 4,
        Fiat = 5
    }

