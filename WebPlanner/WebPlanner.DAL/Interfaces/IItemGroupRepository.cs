using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebPlanner.Domain.Entity;

namespace WebPlanner.DAL.Interfaces
{
    public interface IItemGroupRepository
    {
        public Task<IEnumerable<string>> GetAll();
    }
}
