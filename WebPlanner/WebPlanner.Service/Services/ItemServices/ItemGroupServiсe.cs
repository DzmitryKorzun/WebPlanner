using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebPlanner.DAL.Interfaces;
using WebPlanner.Domain.Entity.GeneralModels;
using WebPlanner.Service.Interfaces.ItemInterfaces;

namespace WebPlanner.Service.Services.ItemServices
{
    public class ItemGroupServiсe : IItemGroupServiсe
    {
        private readonly IItemGroupRepository itemGroupRepository;
        public ItemGroupServiсe(IItemGroupRepository itemGroupRepository)
        {
            this.itemGroupRepository = itemGroupRepository;
        }

        public async Task<BaseResponse<int>> AddNewItemGroup(string name)
        {
            if (String.IsNullOrEmpty(name))
            {
                return new BaseResponse<int>
                {
                    Data = -1,
                    StatusCode = ResponseStatus.InternalServerError,
                    Message = Resource.AppResourses.RESPONSE_STATUS_NAME_OF_ITEMGROUP_IS_NULL_OR_EMPTY
                };
            }
            ItemGroup newItemGroup = new()
            {
                Name = name,
            };
            int result = await itemGroupRepository.Add(newItemGroup);
            if (result == 0)
            {
                return new BaseResponse<int>
                {
                    Data = -1,
                    StatusCode = ResponseStatus.OK,
                    Message = Resource.AppResourses.RESPONSE_STATUS_OK
                };
            }
            return new BaseResponse<int>
            {
                Data = 1,
                StatusCode = ResponseStatus.OK,
                Message = Resource.AppResourses.RESPONSE_STATUS_NAME_OF_ITEMGROUP_IS_NULL_OR_EMPTY
            };
        }

        public async Task<BaseResponse<IEnumerable<string>>> GetAll()
        {
            var result = await itemGroupRepository.GetAll();
            if (result == null)
            {
                return new BaseResponse<IEnumerable<string>>
                {
                    Data = null,
                    Message = Resource.AppResourses.RESPONSE_STATUS_ITEMGROUP_NOT_FOUND,
                    StatusCode = ResponseStatus.NoData
                };
            }
            else
            {
                return new BaseResponse<IEnumerable<string>>
                {
                    Data = result,
                    StatusCode = ResponseStatus.OK
                };
            }
        }
    }
}
