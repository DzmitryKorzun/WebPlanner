using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace WebPlanner.Domain.Entity.GeneralModels
{
    public class TV_Type
    {
        [Key]
        public int ID_TV_Type { get; set; }
        public string? Name { get; set; }

        public override bool Equals(object? obj)
        {
            return obj is TV_Type type &&
                   ID_TV_Type == type.ID_TV_Type &&
                   Name == type.Name;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(ID_TV_Type, Name);
        }
    }
}
