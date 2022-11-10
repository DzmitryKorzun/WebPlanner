using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace WebPlanner.Domain.Entity.GeneralModels
{
    public class ScreenType
    {
        [Key]
        public int ScreenId { get; set; }
        public string? ScreenName { get; set; }
    }
}
