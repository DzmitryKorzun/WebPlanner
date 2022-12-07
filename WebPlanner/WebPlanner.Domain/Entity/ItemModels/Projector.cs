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

        public override bool Equals(object? obj)
        {
            return obj is Projector projector &&
                   Id == projector.Id &&
                   Name == projector.Name &&
                   IdManufacturer == projector.IdManufacturer &&
                   IdLightSource == projector.IdLightSource &&
                   IdProjectorPurpose == projector.IdProjectorPurpose &&
                   IdProjectorMatrixType == projector.IdProjectorMatrixType &&
                   LightFlow == projector.LightFlow &&
                   Contrast == projector.Contrast &&
                   MaxScreenSize == projector.MaxScreenSize &&
                   MinScreenSize == projector.MinScreenSize &&
                   EqualityComparer<Manufacturer?>.Default.Equals(Manufacturer, projector.Manufacturer) &&
                   EqualityComparer<LightProjectorSource?>.Default.Equals(LightProjectorSource, projector.LightProjectorSource) &&
                   EqualityComparer<ProjectorPurpose?>.Default.Equals(ProjectorPurpose, projector.ProjectorPurpose) &&
                   EqualityComparer<ProjectorMatrixType?>.Default.Equals(ProjectorMatrixType, projector.ProjectorMatrixType);
        }

        public override int GetHashCode()
        {
            HashCode hash = new HashCode();
            hash.Add(Id);
            hash.Add(Name);
            hash.Add(IdManufacturer);
            hash.Add(IdLightSource);
            hash.Add(IdProjectorPurpose);
            hash.Add(IdProjectorMatrixType);
            hash.Add(LightFlow);
            hash.Add(Contrast);
            hash.Add(MaxScreenSize);
            hash.Add(MinScreenSize);
            hash.Add(Manufacturer);
            hash.Add(LightProjectorSource);
            hash.Add(ProjectorPurpose);
            hash.Add(ProjectorMatrixType);
            return hash.ToHashCode();
        }
    }
}
