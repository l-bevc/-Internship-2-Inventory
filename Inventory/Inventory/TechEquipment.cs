using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Inventory
{
    public class TechEquipment: Product
    {
        public bool HasBatteries { get; set; }
        public ManufacturerComp ManufactComp { get; set; }

        public void Value()
        {
            var helpCurrent = CurrentValue;
            var difference = DateTime.Now.Month - DateOfBuy.Month;
            var miniPrice = 30 * CurrentValue / 100;
            for (var i = 0; i < difference; i++)
            {
                if (CurrentValue > miniPrice)
                {
                    CurrentValue = 95 * CurrentValue / 100;
                }
                else
                {
                    CurrentValue = miniPrice;
                    break;
                }
            }
        }
    }

    public enum ManufacturerComp
    {
        Apple = 1,
        Hp = 2,
        Fujitsu = 3
    }
}
