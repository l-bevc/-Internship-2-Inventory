using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Inventory
{
    public class TechEquipment : Product
    {
        public bool HasBatteries { get; set; }
        public ManufacturerComp ManufactComp { get; set; }


        public TechEquipment(Guid serialNumber, string description, DateTime dateOfBuy, DateTime guarantyMonths, decimal price,
            bool hasBatteries, ManufacturerComp manufacturerComp) : base(serialNumber, description, dateOfBuy, guarantyMonths, price)
        {
            this.HasBatteries = hasBatteries;
            this.ManufactComp = manufacturerComp;
        }
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

        public static void NumberOfBatteries(List<Computer> list1, List<Phone> list2)
        {
            var numerator = 0;
            foreach (var el in list1)
            {
                if (el.HasBatteries)
                    numerator++;
            }
            foreach (var el in list2)
            {
                if (el.HasBatteries)
                    numerator++;
            }
            Console.WriteLine($"There are {numerator} batteries in tech equipment");
        }
    }

    public enum ManufacturerComp
    {
        Apple = 1,
        Hp = 2,
        Fujitsu = 3
    }
}