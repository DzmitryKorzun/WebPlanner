using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebPlanner.Domain.Entity
{
    public class SmartPhone
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int Id_Manufacturer { get; set; }
        public DateTime MarketDate { get; set; }
        public int RAM { get; set; }
        public int Built_in_memory { get; set; }
        public float ScreenSize { get; set; }
        public int Id_OS { get; set; }
        public int BatteryCapacity { get; set; }
        public int SIM_Card_amount { get; set; }
    }
}
