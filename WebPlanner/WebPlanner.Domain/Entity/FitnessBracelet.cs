using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebPlanner.Domain.Entity
{
    public class FitnessBracelet
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int Id_OS { get; set; }
        public DateTime MarketDate { get; set; }
        public int Id_HousingMaterial { get; set; }
        public int Id_HousingColor { get; set; }
        public int Id_Manufacturer { get; set; }
    }
}
