using System;
using System.Collections.Generic;
using System.Text;

namespace Inventory
{
    public class Computer : TechEquipment
    {
        public string SystemInfo { get; set; }
        public bool IsLaptop { get; set; }

        public Computer(Guid serialNumber, string description, DateTime dateOfBuy, DateTime guarantyMonths, decimal price,
             bool hasBatteries, ManufacturerComp manufacturerComputer, string systemInfo, bool isLaptop)
            : base(serialNumber, description, dateOfBuy, guarantyMonths, price, hasBatteries, manufacturerComputer)
        {
            this.SystemInfo = systemInfo;
            this.IsLaptop = isLaptop;
        }

        public static void PrintComps(List<Computer> listComp)
        {
            foreach (var el in listComp)
            {
                var months = (DateTime.Now - el.DateOfBuy);
                Console.WriteLine($"COMPUTER\nSerial number: {el.SerialNumber}\nDescription: {el.Description}\nDate of buy:{el.DateOfBuy.Date.ToString("MM/dd/yyyy")}\n" +
                                  $"Guaranty: {Math.Truncate(months.TotalDays / 30)}\nPrice: {el.Price}\n" +
                                  $"Manufacturer: {el.ManufactComp}\nHas batteries: {el.HasBatteries}\n" +
                                  $"System info: {el.SystemInfo}\nIs laptop:{el.IsLaptop}\nCurrent value:{el.CurrentValue}\n" +
                                  $"Difference between price and current value:{el.Price - el.CurrentValue}");
            }
        }

        public static void AddingComputer(List<Computer> list)
        {
            Console.WriteLine("Add new computer: ");
            Console.WriteLine("Add description: ");
            var descrip = Console.ReadLine();
            Console.WriteLine("Add date of buy: ");
            var dBuy = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Guaranty duration expires on date: ");
            var days = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Add price: ");
            var price = decimal.Parse(Console.ReadLine());
            Console.WriteLine("Manufacturer 1-Apple, 2-hp, 3-fujitsu");
            var numb = int.Parse(Console.ReadLine());
            var manufac = (ManufacturerComp)numb;
            Console.WriteLine("Has batteries?: ");
            var battery = false;
            if (Console.ReadLine().ToLower() == "yes" || char.Parse(Console.ReadLine().ToLower()) == 'y')
                battery = true;
            Console.WriteLine("Add system info: ");
            var info = Console.ReadLine();
            var laptop = false;
            Console.WriteLine("Is laptop: ");
            if (Console.ReadLine().ToLower() == "yes" || char.Parse(Console.ReadLine().ToLower()) == 'y')
                laptop = true;
            var comp = new Computer(Guid.NewGuid(), descrip, dBuy, days, price, battery, manufac, info, laptop);
            list.Add(comp);
        }

        public static List<Computer> DeleteComputer(List<Computer> list)
        {
            Console.WriteLine("Add a serial number of computer which you want delete:");
            var compNumber = Guid.Parse(Console.ReadLine());
            foreach (var comp in list)
            {
                if (compNumber == comp.SerialNumber)
                {
                    list.Remove(comp);
                }
            }

            return list;
        }

        public static void DetailsOfComputer(List<Computer> list)
        {
            Console.WriteLine("Add serial number: ");
            var numb = Guid.Parse(Console.ReadLine());
            foreach (var el in list)
            {
                el.Value();
                if (numb == el.SerialNumber)
                {
                    var months = (el.GuarantyMonths - el.DateOfBuy);
                    Console.WriteLine($"COMPUTER\nSerial number: {el.SerialNumber}\nDescription: {el.Description}\nDate of buy:{el.DateOfBuy.Date.ToString("MM/dd/yyyy")}\n" +
                                      $"Guaranty duration: {Math.Truncate(months.TotalDays / 30)}\nPrice: {el.Price}\n" +
                                      $"Manufacturer: {el.ManufactComp}\nHas batteries: {el.HasBatteries}\n" +
                                      $"System info: {el.SystemInfo}\nIs laptop:{el.IsLaptop}");
                }
            }
        }

        public static void ExpireComputers(List<Computer> list)
        {
            Console.WriteLine("Add a year: ");
            var year = Console.ReadLine();
            foreach (var el in list)
            {
                if (el.GuarantyMonths.Date.Year.ToString() == year.ToString())
                {
                    Console.WriteLine(el.SerialNumber + "\n" + el.Description);
                }
            }
        }

        public static void ComputerBySystem(List<Computer> list)
        {
            Console.WriteLine("Add system: ");
            var system = Console.ReadLine().ToLower();
            foreach (var el in list)
            {
                if (el.SystemInfo.ToLower() == system)
                {
                    Console.WriteLine(el.SerialNumber + " " + el.Description);
                }
            }
        }
    }
}