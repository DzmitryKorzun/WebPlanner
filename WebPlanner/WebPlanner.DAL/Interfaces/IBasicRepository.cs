using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebPlanner.DAL.Interfaces
{
    public interface IBasicRepository<T>
    {
        public Task<int> Add(T entity);
        public Task<int> Update(int Id);
        public Task<int> Delete (int Id);
    }
}
