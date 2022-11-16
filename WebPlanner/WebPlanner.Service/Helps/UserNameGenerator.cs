
using WebPlanner.Service.Interfaces;

namespace WebPlanner.Helps
{
    public class UserNameGenerator
    {
        private readonly IAccountService accountService;
        public UserNameGenerator(IAccountService accountService)
        {
            this.accountService = accountService;
        }
        public string CreateDefaultUserName()
        {
            return Resource.AppResourses.APP_RES_FIRST_PART_OF_UNIQUE_USERNAME;
        }
    }
}
