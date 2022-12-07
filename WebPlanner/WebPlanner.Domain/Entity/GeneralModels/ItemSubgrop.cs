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

        public override bool Equals(object? obj)
        {
            return obj is ItemSubgroup subgroup &&
                   Id == subgroup.Id &&
                   Name == subgroup.Name &&
                   GroupId == subgroup.GroupId &&
                   EqualityComparer<ItemGroup?>.Default.Equals(ItemGroup, subgroup.ItemGroup);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Name, GroupId, ItemGroup);
        }
    }
}
