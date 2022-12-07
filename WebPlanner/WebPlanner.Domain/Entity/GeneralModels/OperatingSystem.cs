using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace WebPlanner.Domain.Entity.GeneralModels
{
    public class OperatingSystem
    {
        [Key]
        public int Id { get; set; }
        public string? OS_Name { get; set; }

        public override bool Equals(object? obj)
        {
            return obj is OperatingSystem system &&
                   Id == system.Id &&
                   OS_Name == system.OS_Name;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, OS_Name);
        }
    }
}
