﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace WebPlanner.Domain.Entity.GeneralModels
{
    public class HeadphonesConstruction
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }

        public override bool Equals(object? obj)
        {
            return obj is HeadphonesConstruction construction &&
                   Id == construction.Id &&
                   Name == construction.Name;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Name);
        }
    }
}
