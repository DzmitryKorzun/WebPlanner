using Moq;
using WebPlanner.DAL.Interfaces;
using WebPlanner.Domain.Entity;
using WebPlanner.Service;
using WebPlanner.Service.Interfaces;
using WebPlanner.Service.Services;

namespace Tests
{
    public class AccountServiceTests
    {
        private readonly MoqInit moqInit;
        private readonly Mock<IAccountRepository> _accountRepository;
        private readonly IAccountService _accountService;

        public AccountServiceTests()
        {
            this.moqInit = new MoqInit();
            this._accountRepository = moqInit.MockAccountRepository();
            this._accountService = new AccountService(this._accountRepository.Object);
        }

        [Fact]
        public async void GetAccountByEmail()
        {
            var result = await _accountService.GetAccountByEmail(moqInit?.mockData[0]?.Email);
            var expectedObject = new BaseResponse<Account>()
            {
                Data = moqInit?.mockData[0],
                Message = Resource.AppResourses.RESPONSE_STATUS_OK,
                StatusCode = ResponseStatus.OK
            };

            var result_ERROR = await _accountService.GetAccountByEmail(null);
            var expectedObject_ERROR = new BaseResponse<Account>
            {
                Data = null,
                Message = Resource.AppResourses.RESPONSE_STATUS_USER_EMAIL_IS_NULL,
                StatusCode = ResponseStatus.InternalServerError
            };

            var result_UserNotFind = await _accountService.GetAccountByEmail("@");
            var expectedObject_UserNotFind = new BaseResponse<Account>
            {
                Data = null,
                Message = Resource.AppResourses.RESPONSE_STATUS_USER_NOT_FOUND,
                StatusCode = ResponseStatus.NoData
            };
            Assert.StrictEqual(expectedObject_UserNotFind, result_UserNotFind);
            Assert.StrictEqual(expectedObject_ERROR, result_ERROR);
            Assert.StrictEqual(expectedObject, result);
        }
    }
}