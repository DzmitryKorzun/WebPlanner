using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebPlanner.Domain.Entity.ItemModels;

namespace WebPlanner.Domain.Entity.GeneralModels
{
    public class Color
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public List<FitnessBracelet>? FitnessBracelets { get; set; }
        public List<SmartPhone>? SmartPhones { get; set; }
        public List<Tablet>? Tablets { get; set; }

        public override bool Equals(object? obj)
        {
            return obj is Color color &&
                   Id == color.Id &&
                   Name == color.Name &&
                   EqualityComparer<List<FitnessBracelet>?>.Default.Equals(FitnessBracelets, color.FitnessBracelets) &&
                   EqualityComparer<List<SmartPhone>?>.Default.Equals(SmartPhones, color.SmartPhones) &&
                   EqualityComparer<List<Tablet>?>.Default.Equals(Tablets, color.Tablets);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Name, FitnessBracelets, SmartPhones, Tablets);
        }
    }
}