using System;
using System.Collections.Generic;
using System.Text;

namespace Inventory
{
    public class Phone : TechEquipment
    {
        public string PhoneNumber { get; set; }
        public string NameSurname { get; set; }

        public Phone(Guid serialNumber, string description, DateTime dateOfBuy, DateTime guarantyMonths, decimal price,
             bool hasBatteries, ManufacturerComp manufacturerPhone, string phoneNumber, string nameSurname)
            : base(serialNumber, description, dateOfBuy, guarantyMonths, price, hasBatteries, manufacturerPhone)
        {
            this.PhoneNumber = phoneNumber;
            this.NameSurname = nameSurname;
        }

        public static void PrintPhone(List<Phone> listPhon)
        {
            foreach (var el in listPhon)
            {
                el.Value();
                var months = (DateTime.Now - el.DateOfBuy).TotalDays;
                Console.WriteLine($"PHONE\nSerial number: {el.SerialNumber}\nDescription: {el.Description}\nDate of buy:{el.DateOfBuy.Date.ToString("MM/dd/yyyy")}\n" +
                                  $"Guaranty: {Math.Truncate(months / 30)}\nPrice: {el.Price}\n" +
                                  $"Manufacturer: {el.ManufactComp}\nHas batteries: {el.HasBatteries}\n" +
                                  $"Phone number: {el.PhoneNumber}\nName: {el.NameSurname}\nCurrent value:{el.CurrentValue}\n" +
                                  $"Difference between price and current value:{el.Price - el.CurrentValue}");
            }
        }

        public static void AddingPhone(List<Phone> list)
        {
            Console.WriteLine("Add new phone: ");
            Console.WriteLine("Add description: ");
            var descrip2 = Console.ReadLine();
            Console.WriteLine("Add date of buy: ");
            var dBuy2 = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Guaranty duration in days: ");
            Console.WriteLine("Guaranty duration expires on date: ");
            var days2 = DateTime.Parse(Console.ReadLine());
            var price2 = decimal.Parse(Console.ReadLine());
            Console.WriteLine("Manufacturer 1-Apple, 2-hp, 3-fujitsu");
            var numb2 = int.Parse(Console.ReadLine());
            var manufac2 = (ManufacturerComp)numb2;
            var battery2 = false;
            Console.WriteLine("Has batteries?: ");
            if (Console.ReadLine().ToLower() == "yes" || char.Parse(Console.ReadLine().ToLower()) == 'y')
                battery2 = true;
            Console.WriteLine("Add number: ");
            var numberPhone = Console.ReadLine();
            Console.WriteLine("Name and surname: ");
            var name = Console.ReadLine();
            var phon = new Phone(Guid.NewGuid(), descrip2, dBuy2, days2, price2, battery2, manufac2, numberPhone, name);
            list.Add(phon);
        }

        public static List<Phone> DeletePhone(List<Phone> list)
        {
            Console.WriteLine("Add a serial number of phone which you want delete:");
            var phoneNumber = Guid.Parse(Console.ReadLine());
            foreach (var phone in list)
            {
                if (phoneNumber == phone.SerialNumber)
                {
                    list.Remove(phone);
                }
            }

            return list;
        }

        public static void DetailsOfPhone(List<Phone> list)
        {
            Console.WriteLine("Add serial number: ");
            var numb = Guid.Parse(Console.ReadLine());
            foreach (var el in list)
            {
                el.Value();
                if (numb == el.SerialNumber)
                {
                    var months = (el.GuarantyMonths - el.DateOfBuy).TotalDays;
                    Console.WriteLine($"PHONE\nSerial number: {el.SerialNumber}\nDescription: {el.Description}\nDate of buy:{el.DateOfBuy.Date.ToString("MM/dd/yyyy")}\n" +
                                      $"Guaranty duration: {Math.Truncate(months / 30)}\nPrice: {el.Price}\n" +
                                      $"Manufacturer: {el.ManufactComp}\nHas batteries: {el.HasBatteries}\n" +
                                      $"Phone number: {el.PhoneNumber}\nName: {el.NameSurname}");
                }
            }
        }

        public static void PhoneByMark(List<Phone> list)
        {
            Console.WriteLine("Add mark: ");
            var mark = Console.ReadLine();
            var first = char.Parse(mark[0].ToString().ToUpper());
            var end = mark.Remove(0, 1);
            mark = first + end;
            foreach (var el in list)
            {
                if (el.ManufactComp.ToString() == mark)
                {
                    Console.WriteLine(el.PhoneNumber);
                }
            }
        }

        public static void NameAndNumber(List<Phone> list)
        {
            Console.WriteLine("Add a year: ");
            var year = Console.ReadLine();
            foreach (var phone in list)
            {
                if (phone.GuarantyMonths.Date.Year.ToString() == year)
                    Console.WriteLine(phone.NameSurname + " " + phone.PhoneNumber);
            }
        }
    }
}

