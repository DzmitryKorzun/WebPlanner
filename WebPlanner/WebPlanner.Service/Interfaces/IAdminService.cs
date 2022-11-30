using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebPlanner.Domain.Entity.GeneralModels;

namespace WebPlanner.Service.Interfaces
{
    public interface IAdminService
    {
        public Task<BaseResponse<ItemGroup>> GetAllItemGroup();
        public Task<BaseResponse<ItemSubgroup>> GetAllItemSubgroup();
        public Task<BaseResponse<int>> AddNewItemGroup(string name);
        public Task<BaseResponse<int>> AddNewItemSubgroup(string name);
    }
}
