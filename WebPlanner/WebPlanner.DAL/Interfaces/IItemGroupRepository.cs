using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebPlanner.DAL.Repositories;
using WebPlanner.Domain.Entity;
using WebPlanner.Domain.Entity.GeneralModels;

namespace WebPlanner.DAL.Interfaces
{
    public interface IItemGroupRepository:IBasicRepository<ItemGroup>
    {
        public Task<IEnumerable<string>> GetAll();
    }
}
