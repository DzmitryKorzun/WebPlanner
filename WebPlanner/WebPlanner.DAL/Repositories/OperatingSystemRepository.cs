using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebPlanner.DAL.Interfaces;

namespace WebPlanner.DAL.Repositories
{
    public class OperatingSystemRepository : IOperatingSystemRepository
    {
        public Task<int> Add(Domain.Entity.GeneralModels.OperatingSystem entity)
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
