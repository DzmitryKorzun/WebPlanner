using Microsoft.AspNetCore.Mvc;

namespace WebPlanner.Controllers
{
    public class MyDayController : Controller
    {
        [HttpGet]
        public IActionResult ShowMyDay()
        {

            return View();
        }
    }
}
