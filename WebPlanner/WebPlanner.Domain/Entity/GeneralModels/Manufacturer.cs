using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace WebPlanner.Domain.Entity.GeneralModels
{
    public class Manufacturer
    {
        [Key]
        public int Id { get; set; }
        public string? ManufacturerName { get; set; }

        public override bool Equals(object? obj)
        {
            return obj is Manufacturer manufacturer &&
                   Id == manufacturer.Id &&
                   ManufacturerName == manufacturer.ManufacturerName;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, ManufacturerName);
        }
    }
}
