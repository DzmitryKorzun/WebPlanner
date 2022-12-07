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

        public override bool Equals(object? obj)
        {
            return obj is FitnessBracelet bracelet &&
                   Id == bracelet.Id &&
                   Name == bracelet.Name &&
                   Id_OS == bracelet.Id_OS &&
                   MarketDate == bracelet.MarketDate &&
                   Id_HousingMaterial == bracelet.Id_HousingMaterial &&
                   Id_HousingColor == bracelet.Id_HousingColor &&
                   Id_Manufacturer == bracelet.Id_Manufacturer &&
                   EqualityComparer<GeneralModels.OperatingSystem?>.Default.Equals(OperatingSystem, bracelet.OperatingSystem) &&
                   EqualityComparer<Materials?>.Default.Equals(Materials, bracelet.Materials) &&
                   EqualityComparer<Color?>.Default.Equals(Color, bracelet.Color) &&
                   EqualityComparer<Manufacturer?>.Default.Equals(Manufacturer, bracelet.Manufacturer);
        }

        public override int GetHashCode()
        {
            HashCode hash = new HashCode();
            hash.Add(Id);
            hash.Add(Name);
            hash.Add(Id_OS);
            hash.Add(MarketDate);
            hash.Add(Id_HousingMaterial);
            hash.Add(Id_HousingColor);
            hash.Add(Id_Manufacturer);
            hash.Add(OperatingSystem);
            hash.Add(Materials);
            hash.Add(Color);
            hash.Add(Manufacturer);
            return hash.ToHashCode();
        }
    }
}
