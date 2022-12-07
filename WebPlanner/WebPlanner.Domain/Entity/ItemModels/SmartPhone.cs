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
    public class SmartPhone
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        [ForeignKey("Id_Manufacturer")]
        public int Id_Manufacturer { get; set; }
        public DateTime MarketDate { get; set; }
        public int RAM { get; set; }
        public int Built_in_memory { get; set; }
        public float ScreenSize { get; set; }
        [ForeignKey("Id_OS")]
        public int Id_OS { get; set; }
        public int BatteryCapacity { get; set; }
        public int SIM_Card_amount { get; set; }
        [ForeignKey("Id_ScreenType")]
        public int Id_ScreenType { get; set; }
        [ForeignKey("Id_Color")]
        public int Id_Color { get; set; }
        [ForeignKey("Id_Material")]
        public int Id_Material { get; set; }
        public Manufacturer? Manufacturer { get; set; }
        public WebPlanner.Domain.Entity.GeneralModels.OperatingSystem? OperatingSystem { get; set; }
        public ScreenType? ScreenType { get; set; }
        public Color? Color { get; set; }
        public Materials? Materials { get; set; }

        public override bool Equals(object? obj)
        {
            return obj is SmartPhone phone &&
                   Id == phone.Id &&
                   Name == phone.Name &&
                   Id_Manufacturer == phone.Id_Manufacturer &&
                   MarketDate == phone.MarketDate &&
                   RAM == phone.RAM &&
                   Built_in_memory == phone.Built_in_memory &&
                   ScreenSize == phone.ScreenSize &&
                   Id_OS == phone.Id_OS &&
                   BatteryCapacity == phone.BatteryCapacity &&
                   SIM_Card_amount == phone.SIM_Card_amount &&
                   Id_ScreenType == phone.Id_ScreenType &&
                   Id_Color == phone.Id_Color &&
                   Id_Material == phone.Id_Material &&
                   EqualityComparer<Manufacturer?>.Default.Equals(Manufacturer, phone.Manufacturer) &&
                   EqualityComparer<GeneralModels.OperatingSystem?>.Default.Equals(OperatingSystem, phone.OperatingSystem) &&
                   EqualityComparer<ScreenType?>.Default.Equals(ScreenType, phone.ScreenType) &&
                   EqualityComparer<Color?>.Default.Equals(Color, phone.Color) &&
                   EqualityComparer<Materials?>.Default.Equals(Materials, phone.Materials);
        }

        public override int GetHashCode()
        {
            HashCode hash = new HashCode();
            hash.Add(Id);
            hash.Add(Name);
            hash.Add(Id_Manufacturer);
            hash.Add(MarketDate);
            hash.Add(RAM);
            hash.Add(Built_in_memory);
            hash.Add(ScreenSize);
            hash.Add(Id_OS);
            hash.Add(BatteryCapacity);
            hash.Add(SIM_Card_amount);
            hash.Add(Id_ScreenType);
            hash.Add(Id_Color);
            hash.Add(Id_Material);
            hash.Add(Manufacturer);
            hash.Add(OperatingSystem);
            hash.Add(ScreenType);
            hash.Add(Color);
            hash.Add(Materials);
            return hash.ToHashCode();
        }
    }
}
