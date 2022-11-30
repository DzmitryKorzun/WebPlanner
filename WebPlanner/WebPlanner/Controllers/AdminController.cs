using Microsoft.AspNetCore.Mvc;

namespace WebPlanner.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult AdminPanel()
        {
            return View();
        }
    }
}
