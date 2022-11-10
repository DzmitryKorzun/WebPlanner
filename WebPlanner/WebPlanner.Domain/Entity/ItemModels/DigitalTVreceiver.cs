using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace WebPlanner.Domain.Entity.ItemModels
{
    public class DigitalTVreceiver
    {
        [Key]
        public int ID { get; set; }
        public string? Name { get; set; }
        public DateTime? MarketDate { get; set; }
        public string? MaxResolution { get; set; }
    }
}
