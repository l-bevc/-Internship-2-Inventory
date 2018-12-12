using System;
using System.Collections.Generic;
using System.Text;

namespace Inventory
{
    public class Computers: TechEquipment
    {
        public string SystemInfo { get; set; }
        public bool IsLaptop { get; set; }
    }
}
