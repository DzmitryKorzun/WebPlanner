using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebPlanner.Domain.Entity
{
    public class Headphones
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int Id_Manufacturer { get; set; }
        public int Id_HeadphonesConstruction { get; set; }
        public bool IsWireless { get; set; }
    }
}
