using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebPlanner.Domain.Auxiliary_Models;
using WebPlanner.Domain.Entity;
using WebPlanner.Service.Interfaces;

namespace WebPlanner.Controllers
{
    public sealed class AccountController : Controller
    {
        private readonly IAccountService accountService; 
        public AccountController(IAccountService accountService)
        {
            this.accountService = accountService;
        }
        [Authorize]

        public async Task<IActionResult> SetUpAccount()
        {
            if (User?.Identity?.Name != null)
            {
                var account = await accountService.GetAccountByEmail(User.Identity.Name);
                if (account.StatusCode == Service.ResponseStatus.OK)
                {
                    var userSetup = accountService.CreateUserSettingModel(account.Data);
                    return View(userSetup);
                }
                return RedirectToAction("Error");
            }
            else
            {
                return RedirectToAction("Error");
            }
        }
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> UpdateProfileInformation(UserSettingModel account)
        {
            var updatedAccount = new Account()
            {
                Email = User?.Identity?.Name,
                Name = account.Name,
                Bio = account.Bio,
                URL = account.URL,
                Location = account.Location,
            };
            var resultUpdate = await accountService.UpdateProfileInformation(updatedAccount);
            if (resultUpdate.StatusCode == Service.ResponseStatus.OK)
            {
                return RedirectToAction("SetUpAccount", "Account");
            }
            return RedirectToAction("Error");
        }
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> ChangePassword(UserSettingModel userSettingModel)
        {
            var changeResponse = await accountService.ChangePassword(User?.Identity?.Name, 
                userSettingModel.OldPassword, userSettingModel.NewPassword);
            if (changeResponse.StatusCode == Service.ResponseStatus.OK)
            {
                return RedirectToAction("SetUpAccount", "Account");
            }
            return RedirectToAction("Error");
        }
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult AdminPanel()
        {
            return View();
        }
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult AdminPanel(string res)
        {
            return View();
        }

    }
}
