using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebPlanner.DAL.Interfaces;
using WebPlanner.Domain.Entity.GeneralModels;

namespace WebPlanner.DAL.Repositories
{
    public class HeadphonesConstructionRepository : IHeadphonesConstructionRepository
    {
        public Task<int> Add(HeadphonesConstruction entity)
        {
            throw new NotImplementedException();
        }

        public Task<int> Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<int> Update(int Id)
        {
            throw new NotImplementedException();
        }
    }
}
