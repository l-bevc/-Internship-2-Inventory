using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Inventory
{
    public class Vehicle : Product
    {

        public DateTime ExpirationTime { get; set; }
        public decimal Distance { get; set; }
        public Manufacturer Manufact { get; set; }

        public void ValueVehicle()
        {
            CurrentValue = Price;
            var change = Math.Truncate((Distance / 20000));
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


        public Vehicle(Guid serialNumber, string description, DateTime dateOfBuy, DateTime guarantyMonths,
            decimal price, DateTime expirationTime, decimal distance, Manufacturer manufacturer)
            : base(serialNumber, description, dateOfBuy, guarantyMonths, price)
        {
            this.ExpirationTime = expirationTime;
            this.Distance = distance;
            this.Manufact = manufacturer;
        }

        public static void PrintVeh(List<Vehicle> listVeh)
        {
            foreach (var el in listVeh)
            {
                el.ValueVehicle();
                var months = (DateTime.Now - el.DateOfBuy).TotalDays;
                Console.WriteLine($"VEHICLE\nSerial number: {el.SerialNumber}\nDescription: {el.Description}\nDate of buy:{el.DateOfBuy.Date.ToString("MM/dd/yyyy")}\n" +
                                  $"Guaranty: {Math.Truncate(months / 30)}\nPrice: {el.Price}\n" +
                                  $"Manufacturer: {el.Manufact}\nExpiration time: {el.ExpirationTime.ToString("MM/dd/yyyy")}\n" +
                                  $"Distance: {el.Distance}km\nCurrent value:{el.CurrentValue}\n" +
                                  $"Difference between price and current value:{el.Price - el.CurrentValue}");
            }
        }

        public static void AddingVehicle(List<Vehicle> list)
        {
            Console.WriteLine("Add new vehicle: ");
            Console.WriteLine("Add description: ");
            var descrip3 = Console.ReadLine();
            Console.WriteLine("Add date of buy: ");
            var dBuy3 = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Guaranty duration expires on date: ");
            var days3 = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Add price: ");
            var price3 = decimal.Parse(Console.ReadLine());
            Console.WriteLine("Manufacturer 1-Toyota, 2-Bmw, 3-Mercedes, 4-Opel, 5-Fiat");
            var numb3 = int.Parse(Console.ReadLine());
            var manufac3 = (Manufacturer)numb3;
            Console.WriteLine("Date expiration registry?: ");
            var expiration = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Kilometers: ");
            var km = decimal.Parse(Console.ReadLine());
            var vehicl = new Vehicle(Guid.NewGuid(), descrip3, dBuy3, days3, price3, expiration, km, manufac3);
            list.Add(vehicl);
        }

        public static List<Vehicle> DeleteVehicle(List<Vehicle> list)
        {
            Console.WriteLine("Add a serial number of vehicle which you want delete:");
            var vehNumber = Guid.Parse(Console.ReadLine());
            foreach (var veh in list)
            {
                if (vehNumber == veh.SerialNumber)
                {
                    list.Remove(veh);
                }
            }

            return list;
        }

        public static void VehicleExpiresInMonth(List<Vehicle> list)
        {
            foreach (var el in list)
            {
                if (el.ExpirationTime.Year == DateTime.Now.Year && (el.ExpirationTime.Month == DateTime.Now.Month || el.ExpirationTime.Month == DateTime.Now.Month + 1))
                    Console.WriteLine(el.SerialNumber + " " + el.Description);
            }
        }

        public static void DetailsOfVehicle(List<Vehicle> list)
        {
            Console.WriteLine("Add serial number: ");
            var numb = Guid.Parse(Console.ReadLine());
            foreach (var el in list)
            {
                el.ValueVehicle();
                if (numb == el.SerialNumber)
                {
                    var months = (el.GuarantyMonths - el.DateOfBuy).TotalDays;
                    Console.WriteLine($"VEHICLE\nSerial number: {el.SerialNumber}\nDescription: {el.Description}\nDate of buy:{el.DateOfBuy.Date.ToString("MM/dd/yyyy")}\n" +
                                      $"Guaranty duration: {Math.Truncate(months / 30)}\nPrice: {el.Price}\n" +
                                      $"Manufacturer: {el.Manufact}\nExpiration time: {el.ExpirationTime.ToString("MM/dd/yyyy")}\n" +
                                      $"Distance: {el.Distance}km");
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


