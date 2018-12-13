using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Runtime.CompilerServices;

namespace Inventory
{
    class Program
    {
        static void Main(string[] args)
        {
            var date1= new DateTime(2018, 12,13);
            var listOfVehicles = new List<Vehicle>()
            {
                new Vehicle()
                {
                    SerialNumber = Guid.NewGuid(),
                    Description = "first car",
                    DateOfBuy = new DateTime(2016,12, 05).Date,
                    GuarantyMonths =  new DateTime(2018,10,01).Date,
                    Price= 50000,
                    Manufact = Manufacturer.Fiat,
                    ExpirationTime = new DateTime(2019, 01, 29).Date,
                    Distance = 100000
                },
                new Vehicle()
                {
                    SerialNumber = Guid.NewGuid(),
                    Description = "second car",
                    DateOfBuy = new DateTime(2017,11, 05).Date,
                    GuarantyMonths =   new DateTime(2017,10,10).Date,
                    Price= 50m,
                    Manufact = Manufacturer.Bmw,
                    ExpirationTime = new DateTime(2025, 12, 31).Date,
                    Distance = 500000
                }
            };
            var listOfComputers = new List<Computer>()
            {
                new Computer()
                {
                    SerialNumber = Guid.NewGuid(),
                    Description = "first computer",
                    DateOfBuy = new DateTime(2010,10, 15).Date, 
                    GuarantyMonths = new DateTime(2015,03,03).Date,
                    Price= 5000,
                    ManufactComp = ManufacturerComp.Hp,
                    HasBatteries = true,
                    SystemInfo = "windows 10",
                    IsLaptop = true
                }
            };
            var listOfPhones = new List<Phone>()
            {
                new Phone()
                {
                    SerialNumber = Guid.NewGuid(),
                    Description = "first phone",
                    DateOfBuy = new DateTime(2018,12, 01).Date,
                    GuarantyMonths =   new DateTime(2020,12,10).Date,
                    Price= 7000,
                    ManufactComp = ManufacturerComp.Apple,
                    HasBatteries = true,
                    PhoneNumber = "003859967832",
                    NameSurname = "Laura Bevc"
                }
            };
            Console.WriteLine();
            PrintComps(listOfComputers);
            PrintPhone(listOfPhones);
            PrintVeh(listOfVehicles);
            var go = true;
            while (go)
            {
                Console.WriteLine("Choose option: \n1-Add, \n2-Delete, \n3-Details on serial number, \n4-Guaranty expire of computers," +
                                  " \n5-How many batteries are in tech equipment, \n6-Phones of entered mark, \n7-Computer with entered system," +
                                  "\n8-Name and number of those whose garancy expires in input year, \n9-Vehicles which registry expires in a month, \n10-Done");
                var chosen = int.Parse(Console.ReadLine());
                switch (chosen)
                {
                    case 1:
                        Console.WriteLine("1-Computer, 2-Phone, 3-Vehicle");
                        var chosen2 = int.Parse(Console.ReadLine());
                        switch (chosen2)
                        {
                            case 1:
                                var comp = AddingComputer();
                                listOfComputers.Add(comp);
                                break;
                            case 2:
                                var phon = AddingPhone();
                                listOfPhones.Add(phon);
                                break;

                            case 3:
                                var vehicl = AddingVehicle();
                                listOfVehicles.Add(vehicl);
                                break;
                            default:
                                Console.WriteLine("You have chosen an option that does not exist!");
                                break;
                        }
                        break;
                    case 2:
                        Console.WriteLine("Delete 1-Computer, 2-Phone, 3-Vehicle");
                        var chosen3 = int.Parse(Console.ReadLine());
                        switch (chosen3)
                        {
                            case 1:
                                listOfComputers = DeleteComputer(listOfComputers);
                                break;
                            case 2:
                                listOfPhones = DeletePhone(listOfPhones);
                                break;

                            case 3:
                                listOfVehicles = DeleteVehicle(listOfVehicles);
                                break;
                            default:
                                Console.WriteLine("You have chosen an option that does not exist!");
                                break;
                        }
                        break;
                    case 3:
                        Console.WriteLine("1-Computer, 2-Phone, 3-Vehicle");
                        var chosen4 = int.Parse(Console.ReadLine());
                        switch (chosen4)
                        {
                            case 1:
                                DetailsOfComputer(listOfComputers);
                                break;
                            case 2:
                                DetailsOfPhone(listOfPhones);
                                break;

                            case 3:
                                DetailsOfVehicle(listOfVehicles);
                                break;
                            default:
                                Console.WriteLine("You have chosen an option that does not exist!");
                                break;
                        }
                        break;
                    case 4:
                        ExpireComputers(listOfComputers);
                        break;
                    case 5:
                        NumberOfBatteries(listOfComputers, listOfPhones);
                        break;
                    case 6:
                        PhoneByMark(listOfPhones);
                        break;
                    case 7:
                        ComputerBySystem(listOfComputers);
                        break;
                    case 8:
                        NameAndNumber(listOfPhones);
                        break;
                    case 9:
                        VehicleExpiresInMonth(listOfVehicles);
                        break;
                    case 10:
                        go = false;
                        break;
                    default:
                        go = true;
                        break;
                }
            }
        }

        static Computer AddingComputer()
        {
            
            Console.WriteLine("Add new computer: ");
            Console.WriteLine("Add description: ");
            var descrip = Console.ReadLine();
            Console.WriteLine("Add date of buy: ");
            var dBuy = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Guaranty duration expires on date: ");
            var days = new DateTime(long.Parse(Console.ReadLine()));
            Console.WriteLine("Add price: ");
            var price = decimal.Parse(Console.ReadLine());
            Console.WriteLine("Manufacturer 1-Apple, 2-hp, 3-fujitsu");
            var numb = int.Parse(Console.ReadLine());
            var manufac = (ManufacturerComp)numb;
            Console.WriteLine("Has batteries?: ");
            var battery = bool.Parse(Console.ReadLine());
            Console.WriteLine("Add system info: ");
            var info = Console.ReadLine();
            Console.WriteLine("Is laptop: ");
            var laptop = bool.Parse(Console.ReadLine());
            var comp = new Computer()
            {
                SerialNumber = Guid.NewGuid(),
                Description = descrip,
                DateOfBuy = dBuy,
                GuarantyMonths = days,
                Price = price,
                ManufactComp = manufac,
                HasBatteries = battery,
                SystemInfo = info,
                IsLaptop = laptop
            };
            return comp;
        }

        static Phone AddingPhone()
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
            Console.WriteLine("Has batteries?: ");
            var battery2 = bool.Parse(Console.ReadLine());
            Console.WriteLine("Add number: ");
            var numberPhone = Console.ReadLine();
            Console.WriteLine("Name and surname: ");
            var name = Console.ReadLine();
            var phon = new Phone()
            {
                SerialNumber = Guid.NewGuid(),
                Description = descrip2,
                DateOfBuy = dBuy2,
                GuarantyMonths = days2,
                Price = price2,
                ManufactComp = manufac2,
                HasBatteries = battery2,
                PhoneNumber = numberPhone,
                NameSurname = name
            };
            return phon;
        }

        static Vehicle AddingVehicle()
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
            var vehicl = new Vehicle()
            {
                SerialNumber = Guid.NewGuid(),
                Description = descrip3,
                DateOfBuy = dBuy3,
                GuarantyMonths = days3,
                Price = price3,
                Manufact = manufac3,
                ExpirationTime = expiration,
                Distance = km
            };
            return vehicl;
        }

        static List<Computer> DeleteComputer(List<Computer> list)
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

        static List<Phone> DeletePhone(List<Phone> list)
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

        static List<Vehicle> DeleteVehicle(List<Vehicle> list)
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

        static void PrintComps(List<Computer>listComp)
        {   
            foreach (var el in listComp)
            {
                var months = (DateTime.Now-el.DateOfBuy);
                Console.WriteLine($"COMPUTER\nSerial number: {el.SerialNumber}\nDescription: {el.Description}\nDate of buy:{el.DateOfBuy.Date.ToString("MM/dd/yyyy")}\n" +
                                  $"Guaranty in: {months.TotalDays}\nPrice: {el.Price}\n" +
                                  $"Manufacturer: {el.ManufactComp}\nHas batteries: {el.HasBatteries}\n" +
                                  $"System info: {el.SystemInfo}\nIs laptop:{el.IsLaptop}");
            }
        }

        static void PrintPhone(List<Phone> listPhon)
        {
            foreach (var el in listPhon)
            {
                var months = (DateTime.Now - el.DateOfBuy).TotalDays ;
                Console.WriteLine($"PHONE\nSerial number: {el.SerialNumber}\nDescription: {el.Description}\nDate of buy:{el.DateOfBuy.Date.ToString("MM/dd/yyyy")}\n" +
                                  $"Guaranty in months: {months}\nPrice: {el.Price}\n" +
                                  $"Manufacturer: {el.ManufactComp}\nHas batteries: {el.HasBatteries}\n" +
                                  $"Phone number: {el.PhoneNumber}\nName: {el.NameSurname}");
            }
        }

        static void PrintVeh(List<Vehicle> listVeh)
        {
            foreach (var el in listVeh)
            {
                var months = (DateTime.Now - el.DateOfBuy).TotalDays;
                Console.WriteLine($"VEHICLE\nSerial number: {el.SerialNumber}\nDescription: {el.Description}\nDate of buy:{el.DateOfBuy.Date.ToString("MM/dd/yyyy")}\n" +
                    $"Guaranty in months: {months}\nPrice: {el.Price}\n" +
                    $"Manufacturer: {el.Manufact}\nExpiration time: {el.ExpirationTime.ToString("MM/dd/yyyy")}\n" +
                                  $"Distance: {el.Distance}km");
            }
        }

        static void DetailsOfComputer(List<Computer>list)
        {
            Console.WriteLine("Add serial number: ");
            var numb = Guid.Parse(Console.ReadLine());
            foreach (var el in list)
            {
                if (numb == el.SerialNumber)
                {
                    var months = (el.GuarantyMonths - el.DateOfBuy);
                    Console.WriteLine($"COMPUTER\nSerial number: {el.SerialNumber}\nDescription: {el.Description}\nDate of buy:{el.DateOfBuy.Date.ToString("MM/dd/yyyy")}\n" +
                                      $"Guaranty duration: {months.TotalDays}\nPrice: {el.Price}\n" +
                                      $"Manufacturer: {el.ManufactComp}\nHas batteries: {el.HasBatteries}\n" +
                                      $"System info: {el.SystemInfo}\nIs laptop:{el.IsLaptop}");
                }
            }
        }

        static void DetailsOfPhone(List<Phone> list)
        {
            Console.WriteLine("Add serial number: ");
            var numb = Guid.Parse(Console.ReadLine());
            foreach (var el in list)
            {
                if (numb == el.SerialNumber)
                {
                    var months = (el.GuarantyMonths- el.DateOfBuy).TotalDays;
                    Console.WriteLine($"PHONE\nSerial number: {el.SerialNumber}\nDescription: {el.Description}\nDate of buy:{el.DateOfBuy.Date.ToString("MM/dd/yyyy")}\n" +
                                      $"Guaranty duration: {months}\nPrice: {el.Price}\n" +
                                      $"Manufacturer: {el.ManufactComp}\nHas batteries: {el.HasBatteries}\n" +
                                      $"Phone number: {el.PhoneNumber}\nName: {el.NameSurname}");
                }
            }
        }

        static void DetailsOfVehicle(List<Vehicle> list)
        {
            Console.WriteLine("Add serial number: ");
            var numb = Guid.Parse(Console.ReadLine());
            foreach (var el in list)
            {
                if (numb == el.SerialNumber)
                {
                    var months = (el.GuarantyMonths - el.DateOfBuy).TotalDays;
                    Console.WriteLine($"VEHICLE\nSerial number: {el.SerialNumber}\nDescription: {el.Description}\nDate of buy:{el.DateOfBuy.Date.ToString("MM/dd/yyyy")}\n" +
                                      $"Guaranty duration: {months}\nPrice: {el.Price}\n" +
                                      $"Manufacturer: {el.Manufact}\nExpiration time: {el.ExpirationTime.ToString("MM/dd/yyyy")}\n" +
                                      $"Distance: {el.Distance}km");
                }
            }
        }

        static void ExpireComputers(List<Computer> list)
        {
            Console.WriteLine("Add a year: ");
            var year = Console.ReadLine();
            foreach (var el in list)
            {
                if (el.GuarantyMonths.Date.Year.ToString() == year.ToString())
                {
                    Console.WriteLine(el.SerialNumber+"\n"+el.Description);
                }
            }
        }

        static void NumberOfBatteries(List<Computer> list1, List<Phone> list2)
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

        static void PhoneByMark(List<Phone> list)
        {
            Console.WriteLine("Add mark: ");
            var mark = Console.ReadLine();
            var first = char.Parse(mark[0].ToString().ToUpper());
            var end = mark.Remove(1);
            mark = first + end;
            foreach (var el in list)
            {
                if (el.ManufactComp.ToString() == mark)
                {
                    Console.WriteLine(el.PhoneNumber);
                }
            }
        }

        static void ComputerBySystem(List<Computer> list)
        {
            Console.WriteLine("Add system: ");
            var system = Console.ReadLine().ToLower();
            foreach (var el in list)
            {
                if (el.SystemInfo.ToLower()==system)
                {
                    Console.WriteLine(el.SerialNumber+" "+el.Description);
                }
            }

        }

        static void NameAndNumber(List<Phone> list)
        {
            Console.WriteLine("Add a year: ");
            var year = Console.ReadLine();
            foreach (var phone in list)
            {
                if(phone.GuarantyMonths.Date.Year.ToString()==year)
                    Console.WriteLine(phone.NameSurname+" "+phone.PhoneNumber);
            }
        }

        static void VehicleExpiresInMonth(List<Vehicle> list)
        {
            foreach (var el in list)
            {
                if(el.ExpirationTime.Year==DateTime.Now.Year && (el.ExpirationTime.Month==DateTime.Now.Month || el.ExpirationTime.Month == DateTime.Now.Month+1))
                    Console.WriteLine(el.SerialNumber+ " "+el.Description);
            }
        }
    }
}
