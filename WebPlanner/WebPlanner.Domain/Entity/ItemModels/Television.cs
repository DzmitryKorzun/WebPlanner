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
    }
}
