using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebPlanner.Service.Interfaces
{
    public interface IItemGroupServiсe
    {
        public Task<BaseResponse<IEnumerable<string>>> GetAll();
    }
}
