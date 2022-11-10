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
    public class Headphones
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        [ForeignKey("Id_Manufacturer")]
        public int Id_Manufacturer { get; set; }
        [ForeignKey("Id_HeadphonesConstruction")]
        public int Id_HeadphonesConstruction { get; set; }
        public bool IsWireless { get; set; }
        public Manufacturer? Manufacturer { get; set; }
        public HeadphonesConstruction? HeadphonesConstruction { get; set; }
    }
}
