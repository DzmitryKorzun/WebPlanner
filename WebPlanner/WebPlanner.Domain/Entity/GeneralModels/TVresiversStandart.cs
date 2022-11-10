using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace WebPlanner.Domain.Entity.GeneralModels
{
    public class TVresiversStandart
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
    }
}
