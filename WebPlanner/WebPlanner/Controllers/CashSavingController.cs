using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebPlanner.Controllers
{
    [Authorize]
    public class CashSavingController : Controller
    {


        [HttpGet]
        
        public IActionResult Cash()
        {
            Console.WriteLine(User.Identity.IsAuthenticated);
            return View();
        }
    }
}
