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
    public class ElectronicBook
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        [ForeignKey("IdManufactorer")]
        public int IdManufactorer { get; set; }        
        public int Diagonal { get; set; }
        public bool IsScreenBacklight { get; set; }
        public bool IsSensorDisplay { get; set; }
        public bool IsHasWiFi { get; set; }
        public bool IsColorDisplay { get; set; }
        public string? Resolurion { get; set; }
        public Manufacturer? Manufacturer { get; set; }

        public override bool Equals(object? obj)
        {
            return obj is ElectronicBook book &&
                   Id == book.Id &&
                   Name == book.Name &&
                   IdManufactorer == book.IdManufactorer &&
                   Diagonal == book.Diagonal &&
                   IsScreenBacklight == book.IsScreenBacklight &&
                   IsSensorDisplay == book.IsSensorDisplay &&
                   IsHasWiFi == book.IsHasWiFi &&
                   IsColorDisplay == book.IsColorDisplay &&
                   Resolurion == book.Resolurion &&
                   EqualityComparer<Manufacturer?>.Default.Equals(Manufacturer, book.Manufacturer);
        }

        public override int GetHashCode()
        {
            HashCode hash = new HashCode();
            hash.Add(Id);
            hash.Add(Name);
            hash.Add(IdManufactorer);
            hash.Add(Diagonal);
            hash.Add(IsScreenBacklight);
            hash.Add(IsSensorDisplay);
            hash.Add(IsHasWiFi);
            hash.Add(IsColorDisplay);
            hash.Add(Resolurion);
            hash.Add(Manufacturer);
            return hash.ToHashCode();
        }
    }
}
