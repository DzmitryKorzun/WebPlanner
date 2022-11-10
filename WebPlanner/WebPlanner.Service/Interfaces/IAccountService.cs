using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using WebPlanner.Domain.Auxiliary_Models;
using WebPlanner.Domain.Enums;

namespace WebPlanner.Service.Interfaces
{
    public interface IAccountService
    {
        public Task<BaseResponse<ClaimsIdentity>> Registration(string? email, string? name, string? password);
        public Task<BaseResponse<ClaimsIdentity>> Login(string? email, string? password);
        public Task<BaseResponse<string>> GetLastUserId();
    }
}
