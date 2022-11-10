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
    public class Projector
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        [ForeignKey("IdManufacturer")]
        public int IdManufacturer { get; set; }
        [ForeignKey("IdLightSource")]
        public int IdLightSource { get; set; }
        [ForeignKey("IdProjectorPurpose")]
        public int IdProjectorPurpose { get; set; }
        [ForeignKey("IdProjectorMatrixType")]
        public int IdProjectorMatrixType { get; set; }
        public int LightFlow { get; set; }
        public int Contrast { get; set; }
        public int MaxScreenSize { get; set; }
        public int MinScreenSize { get; set; }
        public Manufacturer? Manufacturer { get; set; }
        public LightProjectorSource? LightProjectorSource { get; set; }
        public ProjectorPurpose? ProjectorPurpose { get; set; }
        public ProjectorMatrixType? ProjectorMatrixType { get; set; }
    }
}
