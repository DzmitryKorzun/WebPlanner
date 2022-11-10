using System.Reflection;
using System.Resources;
using System.Security.Claims;
using WebPlanner.DAL.Interfaces;
using WebPlanner.Domain.Auxiliary_Models;
using WebPlanner.Domain.Entity;
using WebPlanner.Domain.Enums;
using WebPlanner.Helps;
using WebPlanner.Service.Interfaces;

namespace WebPlanner.Service.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository repository;
        public AccountService(IAccountRepository repository)
        {            
            this.repository = repository;
        }

        public async Task<BaseResponse<string>> GetLastUserId()
        {
            var lastId = await repository.GetLastAccountId();
            if (lastId == 0)
            {
                return new BaseResponse<string>
                {
                    Data = null,
                    StatusCode = ResponseStatus.InternalServerError,
                    Message = Resource.AppResourses.RESPONSE_STATUS_USER_NOT_FOUND
                };
            }
            else
            {
                //var uniqueUserName = ;
                return new BaseResponse<string>
                {
                  //  Data = uniqueUserName,
                    StatusCode = ResponseStatus.OK,
                    Message = Resource.AppResourses.RESPONSE_STATUS_OK
                };
            }
        }

        public async Task<BaseResponse<ClaimsIdentity>> Login(string? email, string? password)
        {
            var account = await repository.GetAccountByEmail(email);
            if (account == null)
            {
                return new BaseResponse<ClaimsIdentity>
                {
                    Message = Resource.AppResourses.RESPONSE_STATUS_USER_NOT_FOUND,
                    StatusCode = ResponseStatus.NoData
                };
            }
            else
            {
                var result = Authenticate(account);
                return new BaseResponse<ClaimsIdentity>
                {
                    Data = result,
                    Message = Resource.AppResourses.RESPONSE_STATUS_USER_FOUNDED,
                    StatusCode = ResponseStatus.OK
                };
            }
        }

        public async Task<BaseResponse<ClaimsIdentity>> Registration(string? email, string? name, string? password)
        {
            var account = await repository.GetAccountByEmail(email);
            if (account == null)
            {
                var accountSalt = HashPassword.GenerateSalt();
                var accountPassword = HashPassword.GetHash(password, accountSalt);
                Account newAccount = new Account()
                {
                    Email = email,
                    Name = name,
                    HashPassword = accountPassword,
                    Salt = accountSalt,
                    AccountType = AccountType.User.ToString()
                };
                var newAccountResponse = await repository.Add(newAccount);
                if (newAccountResponse == 1)
                {
                    var result = Authenticate(newAccount);
                    return new BaseResponse<ClaimsIdentity>()
                    {
                        Data = result,
                        StatusCode = ResponseStatus.OK,
                        Message = Resource.AppResourses.RESPONSE_STATUS_OK
                    };
                }
                else
                {
                    return new BaseResponse<ClaimsIdentity>()
                    {
                        StatusCode = ResponseStatus.UnknownError,
                        Message = Resource.AppResourses.RESPONSE_STATUS_UNKNOW_ERROR
                    };
                }
            }
            return new BaseResponse<ClaimsIdentity>()
            {
                StatusCode = ResponseStatus.InternalServerError,
                Message = Resource.AppResourses.RESPONSE_STATUS_USER_FOUNDED
            };
        }

        private ClaimsIdentity Authenticate(Account user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, user.Email),
                new Claim(ClaimsIdentity.DefaultRoleClaimType, user.AccountType)
            };
            return new ClaimsIdentity(claims, "ApplicationCookie",
                ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
        }
    }
}