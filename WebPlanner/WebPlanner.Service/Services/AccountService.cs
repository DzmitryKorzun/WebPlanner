using Microsoft.AspNetCore.Authorization;
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

        public async Task<BaseResponse<string>> CreateDefaultUserName()
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
                var uniqueUserName = String.Concat(Resource.AppResourses.APP_RES_FIRST_PART_OF_UNIQUE_USERNAME,lastId.ToString());
                return new BaseResponse<string>
                {
                    Data = uniqueUserName,
                    StatusCode = ResponseStatus.OK,
                    Message = Resource.AppResourses.RESPONSE_STATUS_OK
                };
            }
        }
        public async Task<BaseResponse<Account>> GetAccountByEmail(string email)
        {
            var account = await repository.GetAccountByEmail(email);
            if (account == null)
            {
                return new BaseResponse<Account>
                {
                    Data = null,
                    StatusCode = ResponseStatus.NoData,
                    Message = Resource.AppResourses.RESPONSE_STATUS_USER_NOT_FOUND
                };
            }
            return new BaseResponse<Account>
            {
                Data = account,
                StatusCode = ResponseStatus.OK,
                Message = Resource.AppResourses.RESPONSE_STATUS_OK
            };
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
                if (HashPassword.PasswordCheck(password, account.HashPassword, account.Salt))
                {
                    var result = Authenticate(account);
                    return new BaseResponse<ClaimsIdentity>
                    {
                        Data = result,
                        Message = Resource.AppResourses.RESPONSE_STATUS_USER_FOUNDED,
                        StatusCode = ResponseStatus.OK
                    };
                }
                return new BaseResponse<ClaimsIdentity>
                {
                    Data = null,
                    Message = Resource.AppResourses.RESPONSE_STATUS_USER_FOUNDED,
                    StatusCode = ResponseStatus.InternalServerError
                };
            }
        }
        public async Task<BaseResponse<ClaimsIdentity>> Registration(string? email, string? name, string? password)
        {
            var account = await repository.GetAccountByEmail(email);
            if (account == null)
            {
                var defaultUserNameResponse = await CreateDefaultUserName();
                if (defaultUserNameResponse.StatusCode == ResponseStatus.OK)
                {
                    var accountSalt = HashPassword.GenerateSalt();
                    var accountPassword = HashPassword.GetHash(password, accountSalt);
                    Account newAccount = new Account()
                    {
                        Email = email,
                        Name = name,
                        HashPassword = accountPassword,
                        Salt = accountSalt,
                        AccountType = AccountType.User.ToString(),
                        UserName = defaultUserNameResponse.Data
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
                else
                {
                    return new BaseResponse<ClaimsIdentity>()
                    {
                        StatusCode = ResponseStatus.UnknownError,
                        Message = Resource.AppResourses.RESPONSE_STATUS_ERROR_CREATING_STANDART_UNIQUE_USERNAME
                    };
                }
            }
            return new BaseResponse<ClaimsIdentity>()
            {
                StatusCode = ResponseStatus.InternalServerError,
                Message = Resource.AppResourses.RESPONSE_STATUS_USER_FOUNDED
            };
        }

        public async Task<BaseResponse<bool>> UpdateProfileInformation(Account updatedAccount)
        {
            var resultResponse = await repository.UpdateProfileInformation(updatedAccount);
            if (resultResponse == 1)
            {
                return new BaseResponse<bool>
                {
                    Data = true,
                    StatusCode = ResponseStatus.OK,
                    Message = Resource.AppResourses.RESPONSE_STATUS_OK
                };
            }
            else
            {
                return new BaseResponse<bool>
                {
                    Data = false,
                    StatusCode = ResponseStatus.InternalServerError,
                    Message = Resource.AppResourses.RESPONSE_STATUS_UPDATE_PROFILE_INFORMATION_FAILED
                };
            }
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
        [Authorize]
        public async Task<BaseResponse<bool>> ChangePassword(string? accountEmail, string? oldPassword, string? newPassword)
        {
            if (string.IsNullOrEmpty(accountEmail))
            {
                return new BaseResponse<bool>
                {
                    Data = false,
                    StatusCode = ResponseStatus.InternalServerError,
                    Message = Resource.AppResourses.RESPONSE_STATUS_USER_EMAIL_IN_CHANGE_PASSWORD_IS_NULL,
                };
            }
            else
            {
                var account = await repository.GetAccountByEmail(accountEmail);
                if (account == null)
                {
                    return new BaseResponse<bool>
                    {
                        Data = false,
                        StatusCode = ResponseStatus.NoData,
                        Message = Resource.AppResourses.RESPONSE_STATUS_USER_NOT_FOUND,
                    };
                }
                else
                {
                    var accountPassword = account.HashPassword;
                    var accountSalt = account.Salt;
                    if (HashPassword.PasswordCheck(oldPassword, accountPassword, accountSalt))
                    {
                        if (string.IsNullOrEmpty(newPassword))
                        {
                            return new BaseResponse<bool>
                            {
                                Data = false,
                                StatusCode = ResponseStatus.InternalServerError,
                                Message = Resource.AppResourses.RESPONSE_STATUS_NEW_PASSWORD_IS_NULL,
                            };
                        }
                        else
                        {
                            var result = await repository.ChangePassword(account, newPassword);
                            if (result > 0)
                            {
                                return new BaseResponse<bool>
                                {
                                    Data = true,
                                    StatusCode = ResponseStatus.OK,
                                    Message = Resource.AppResourses.RESPONSE_STATUS_PASSWORD_SUCCESSFULLY_CHANGED,
                                };
                            }
                            else
                            {
                                return new BaseResponse<bool>
                                {
                                    Data = false,
                                    StatusCode = ResponseStatus.InternalServerError,
                                    Message = Resource.AppResourses.RESPONSE_STATUS_REPOSITORY_COULD_NOT_UPDATE_ACCOUNT_PASSWORD,
                                };
                            }
                        }
                    }
                    else
                    {
                        return new BaseResponse<bool>
                        {
                            Data = false,
                            StatusCode = ResponseStatus.InvalidPassword,
                            Message = Resource.AppResourses.RESPONSE_STATUS_INVALID_PASSWORD
                        };
                    }
                }
            }
            
        }

        public UserSettingModel CreateUserSettingModel(Account? account)
        {
            if (account != null)
            {
                return new UserSettingModel(account.Id, account.Name, account.Email, account.HashPassword,
                    account.Salt, account.AccountType, account.Bio, account.URL, account.Location, account.UserName);
            }
            return null;
        }
    }
}