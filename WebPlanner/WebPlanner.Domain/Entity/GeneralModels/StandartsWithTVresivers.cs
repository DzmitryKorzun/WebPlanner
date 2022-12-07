using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace WebPlanner.Domain.Entity.GeneralModels
{
    public class StandartsWithTVresivers
    {
        [Key]
        public int Id { get; set; }

        public int IdResiver { get; set; }
        public int IdStandart { get; set; }

        public override bool Equals(object? obj)
        {
            return obj is StandartsWithTVresivers vresivers &&
                   Id == vresivers.Id &&
                   IdResiver == vresivers.IdResiver &&
                   IdStandart == vresivers.IdStandart;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, IdResiver, IdStandart);
        }
    }
}
