using Microsoft.AspNetCore.Mvc;
using WebPlanner.Domain.Auxiliary_Models;
using WebPlanner.Service.Interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using WebPlanner.Domain.Enums;
using WebPlanner.Service.Interfaces.ItemInterfaces;

namespace WebPlanner.Controllers
{
    public class HomeController : Controller
    {
        private readonly IItemGroupServiсe itemGroupService;
        private readonly IAccountService accountService;
        public HomeController(IItemGroupServiсe itemGroupService, IAccountService accountService)
        {
            this.itemGroupService = itemGroupService;
            this.accountService = accountService;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(UserManagerModel model)
        {
            var loginResponse = await accountService.Login(model.LoginEmail, model.LoginPassword);
            if (loginResponse.StatusCode == Service.ResponseStatus.OK && loginResponse.Data is not null)
            {
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                        new ClaimsPrincipal(loginResponse.Data));
                if (User.IsInRole(AccountType.User.ToString()))
                {
                    return RedirectToAction("Index", "Home");
                }
                return RedirectToAction("AdminPanel", "Admin");
            }
            else 
            {
                return RedirectToAction("Error");
            }
        }
        [HttpPost]
        public async Task<IActionResult> Register(UserManagerModel model)
        {
            var registerResponse = await accountService.Registration(
                model.RegEmail, model.RegName, model.RegPassword);
            if (registerResponse.StatusCode == Service.ResponseStatus.OK && registerResponse.Data is not null)
            {
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                        new ClaimsPrincipal(registerResponse.Data));
                return RedirectToAction("Index", "Home");
            }
            return RedirectToAction("Error");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

    }
}
