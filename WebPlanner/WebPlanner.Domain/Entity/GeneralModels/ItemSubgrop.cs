using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebPlanner.Domain.Entity.GeneralModels
{
    public class ItemSubgroup
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        [ForeignKey("GroupId")]
        public int GroupId { get; set; }
        public ItemGroup? ItemGroup { get; set; }
    }
}
