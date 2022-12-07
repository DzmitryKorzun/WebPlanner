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
    public class Tablet
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        [ForeignKey("IdManufactorer")]
        public int IdManufactorer { get; set; }
        public DateTime MarketDate { get; set; }
        public int Diagonal { get; set; }
        public string? Resolurion { get; set; }
        public int RAM { get; set; }
        public int Built_in_memory { get; set; }
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
        public Manufacturer? Manufacturer { get; set;}
        public GeneralModels.OperatingSystem? OperatingSystem { get; set; }
        public ScreenType? ScreenType { get; set; }
        public Color? Color { get; set; }
        public Materials? Materials { get; set; }

        public override bool Equals(object? obj)
        {
            return obj is Tablet tablet &&
                   Id == tablet.Id &&
                   Name == tablet.Name &&
                   IdManufactorer == tablet.IdManufactorer &&
                   MarketDate == tablet.MarketDate &&
                   Diagonal == tablet.Diagonal &&
                   Resolurion == tablet.Resolurion &&
                   RAM == tablet.RAM &&
                   Built_in_memory == tablet.Built_in_memory &&
                   Id_OS == tablet.Id_OS &&
                   BatteryCapacity == tablet.BatteryCapacity &&
                   SIM_Card_amount == tablet.SIM_Card_amount &&
                   Id_ScreenType == tablet.Id_ScreenType &&
                   Id_Color == tablet.Id_Color &&
                   Id_Material == tablet.Id_Material &&
                   EqualityComparer<Manufacturer?>.Default.Equals(Manufacturer, tablet.Manufacturer) &&
                   EqualityComparer<GeneralModels.OperatingSystem?>.Default.Equals(OperatingSystem, tablet.OperatingSystem) &&
                   EqualityComparer<ScreenType?>.Default.Equals(ScreenType, tablet.ScreenType) &&
                   EqualityComparer<Color?>.Default.Equals(Color, tablet.Color) &&
                   EqualityComparer<Materials?>.Default.Equals(Materials, tablet.Materials);
        }

        public override int GetHashCode()
        {
            HashCode hash = new HashCode();
            hash.Add(Id);
            hash.Add(Name);
            hash.Add(IdManufactorer);
            hash.Add(MarketDate);
            hash.Add(Diagonal);
            hash.Add(Resolurion);
            hash.Add(RAM);
            hash.Add(Built_in_memory);
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
