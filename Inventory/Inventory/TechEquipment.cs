using System;
using System.Collections.Generic;
using System.Text;

namespace Inventory
{
    public class TechEquipment: Product
    {
        public bool HasBatteries { get; set; }
        public ManufacturerComp ManufactComp { get; set; }
        
    }

    public enum ManufacturerComp
    {
        Apple = 1,
        Hp = 2,
        Fujitsu = 3
    }


}
