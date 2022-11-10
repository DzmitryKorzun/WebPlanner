using Microsoft.AspNetCore.Mvc;

namespace WebPlanner.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult SetUpAccount()
        {
            return View();
        }
    }
}
