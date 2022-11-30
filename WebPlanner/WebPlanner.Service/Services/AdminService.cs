using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebPlanner.Domain.Entity.GeneralModels;
using WebPlanner.Service.Interfaces;
using WebPlanner.Service.Interfaces.ItemInterfaces;

namespace WebPlanner.Service.Services
{
    public class AdminService : IAdminService
    {
        private IItemGroupServiсe itemGroupService;

        public AdminService(IItemGroupServiсe itemGroupService)
        {
            this.itemGroupService = itemGroupService;
        }

        public async Task<BaseResponse<int>> AddNewItemGroup(string name)
        {
            var result = await itemGroupService.AddNewItemGroup(name);
            if (result.StatusCode == ResponseStatus.OK && result.Data == 1)
            {
                return new BaseResponse<int>
                {
                    StatusCode = ResponseStatus.OK,
                    Data = result.Data,
                    Message = result.Message
                };
            }
            return result;
        }

        public Task<BaseResponse<int>> AddNewItemSubgroup(string name)
        {
            throw new NotImplementedException();
        }

        public Task<BaseResponse<ItemGroup>> GetAllItemGroup()
        {
            throw new NotImplementedException();
        }

        public Task<BaseResponse<ItemSubgroup>> GetAllItemSubgroup()
        {
            throw new NotImplementedException();
        }
    }
}
