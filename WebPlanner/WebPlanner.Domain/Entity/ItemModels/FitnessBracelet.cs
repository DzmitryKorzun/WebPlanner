using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebPlanner.Domain.Entity.GeneralModels;

namespace WebPlanner.Domain.Entity.ItemModels
{
    public class FitnessBracelet
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        [ForeignKey("Id_OS")]
        public int Id_OS { get; set; }
        public DateTime MarketDate { get; set; }
        [ForeignKey("Id_HousingMaterial")]
        public int Id_HousingMaterial { get; set; }
        [ForeignKey("Id_HousingColor")]
        public int Id_HousingColor { get; set; }
        [ForeignKey("Id_Manufacturer")]
        public int Id_Manufacturer { get; set; }    
        public WebPlanner.Domain.Entity.GeneralModels.OperatingSystem? OperatingSystem { get; set; }
        public Materials? Materials { get; set; }
        public Color? Color { get; set; }
        public Manufacturer? Manufacturer { get; set; }
    }
}
