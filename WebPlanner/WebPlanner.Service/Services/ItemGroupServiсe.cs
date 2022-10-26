using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebPlanner.DAL.Interfaces;
using WebPlanner.Service.Interfaces;

namespace WebPlanner.Service.Services
{
    public class ItemGroupServiсe: IItemGroupServiсe
    {
        private readonly IItemGroupRepository itemGroupRepository;
        public ItemGroupServiсe(IItemGroupRepository itemGroupRepository)
        {
            this.itemGroupRepository = itemGroupRepository;
        }

        public async Task<BaseResponse<IEnumerable<string>>> GetAll()
        {
            var result = await itemGroupRepository.GetAll();
            if (result == null)
            {
                return new BaseResponse<IEnumerable<string>>
                {
                    Data = null,
                    Message = "Data not found",
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
