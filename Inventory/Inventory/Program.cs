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
            var listOfPhones = new List<Phone>();
            var listOfVehicles = new List<Vehicle>();
            var listOfComputers = new List<Computer>();
            var firstComputer = new Computer(Guid.NewGuid(), "First computer", new DateTime(2010, 10, 15).Date,
                new DateTime(2015, 03, 03).Date, 5000, true, ManufacturerComp.Hp, "windows 10", true);
            listOfComputers.Add(firstComputer);
            var firstCar = new Vehicle(Guid.NewGuid(), "First car", new DateTime(2016, 12, 05).Date,
                new DateTime(2018, 10, 01).Date, 50000, new DateTime(2019, 01, 29).Date, 100000, Manufacturer.Fiat);
            listOfVehicles.Add(firstCar);
            var firstPhone = new Phone(Guid.NewGuid(), "First phone", new DateTime(2018, 12, 01).Date,
                new DateTime(2020, 12, 10).Date, 7000, true, ManufacturerComp.Apple, "003859967832", "Laura Bevc");
            listOfPhones.Add(firstPhone);
            Computer.PrintComps(listOfComputers);
            Vehicle.PrintVeh(listOfVehicles);
            Phone.PrintPhone(listOfPhones);
            var go = true;
            while (go)
            {
                Console.WriteLine("Choose option: \n1-Add, \n2-Delete, \n3-Details on serial number, \n4-Guaranty expire of computers," +
                                  " \n5-How many batteries are in tech equipment, \n6-Phones of entered mark, \n7-Computer with entered system," +
                                  "\n8-Name and number of those whose guaranty expires in input year, \n9-Vehicles which registry expires in a month, \n10-Done");
                var chosen = int.Parse(Console.ReadLine());
                switch (chosen)
                {
                    case 1:
                        Console.WriteLine("1-Computer, 2-Phone, 3-Vehicle");
                        var chosen2 = int.Parse(Console.ReadLine());
                        switch (chosen2)
                        {
                            case 1:
                                Computer.AddingComputer(listOfComputers);
                                break;
                            case 2:
                                Phone.AddingPhone(listOfPhones);
                                break;
                            case 3:
                                Vehicle.AddingVehicle(listOfVehicles);
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
                                listOfComputers = Computer.DeleteComputer(listOfComputers);
                                break;
                            case 2:
                                listOfPhones = Phone.DeletePhone(listOfPhones);
                                break;
                            case 3:
                                listOfVehicles = Vehicle.DeleteVehicle(listOfVehicles);
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
                                Computer.DetailsOfComputer(listOfComputers);
                                break;
                            case 2:
                                Phone.DetailsOfPhone(listOfPhones);
                                break;

                            case 3:
                                Vehicle.DetailsOfVehicle(listOfVehicles);
                                break;
                            default:
                                Console.WriteLine("You have chosen an option that does not exist!");
                                break;
                        }
                        break;
                    case 4:
                        Computer.ExpireComputers(listOfComputers);
                        break;
                    case 5:
                        TechEquipment.NumberOfBatteries(listOfComputers, listOfPhones);
                        break;
                    case 6:
                        Phone.PhoneByMark(listOfPhones);
                        break;
                    case 7:
                        Computer.ComputerBySystem(listOfComputers);
                        break;
                    case 8:
                        Phone.NameAndNumber(listOfPhones);
                        break;
                    case 9:
                        Vehicle.VehicleExpiresInMonth(listOfVehicles);
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
    }
}