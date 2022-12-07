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
    public class Television
    {
        [Key]
        public int TelevisionId { get; set; }
        public string? TelevisionName { get; set; }
        [ForeignKey("Id_Manufactorer")]
        public int Id_Manufactorer { get; set; }
        public DateTime MarketDare { get; set; }
        public int Diagonal { get; set; }
        public string? Resolurion { get; set; }
        [ForeignKey("Id_TV_type")]
        public int Id_TV_type { get; set; }
        public bool IsSmart { get; set; }
        [ForeignKey("Id_ScreenType")]
        public int Id_ScreenType { get; set; }
        public bool IsCurvedScreen { get; set; }
        public Manufacturer? Manufacturer { get; set; }
        public TV_Type? TV_type { get; set; }
        public ScreenType? ScreenType { get; set; }

        public override bool Equals(object? obj)
        {
            return obj is Television television &&
                   TelevisionId == television.TelevisionId &&
                   TelevisionName == television.TelevisionName &&
                   Id_Manufactorer == television.Id_Manufactorer &&
                   MarketDare == television.MarketDare &&
                   Diagonal == television.Diagonal &&
                   Resolurion == television.Resolurion &&
                   Id_TV_type == television.Id_TV_type &&
                   IsSmart == television.IsSmart &&
                   Id_ScreenType == television.Id_ScreenType &&
                   IsCurvedScreen == television.IsCurvedScreen &&
                   EqualityComparer<Manufacturer?>.Default.Equals(Manufacturer, television.Manufacturer) &&
                   EqualityComparer<TV_Type?>.Default.Equals(TV_type, television.TV_type) &&
                   EqualityComparer<ScreenType?>.Default.Equals(ScreenType, television.ScreenType);
        }

        public override int GetHashCode()
        {
            HashCode hash = new HashCode();
            hash.Add(TelevisionId);
            hash.Add(TelevisionName);
            hash.Add(Id_Manufactorer);
            hash.Add(MarketDare);
            hash.Add(Diagonal);
            hash.Add(Resolurion);
            hash.Add(Id_TV_type);
            hash.Add(IsSmart);
            hash.Add(Id_ScreenType);
            hash.Add(IsCurvedScreen);
            hash.Add(Manufacturer);
            hash.Add(TV_type);
            hash.Add(ScreenType);
            return hash.ToHashCode();
        }
    }
}
