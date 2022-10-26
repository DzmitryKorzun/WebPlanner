using Microsoft.AspNetCore.Mvc;
using WebPlanner.Service.Interfaces;

namespace WebPlanner.Controllers
{
    public class HomeController : Controller
    {
        private readonly IItemGroupServiсe itemGroupService;
        public HomeController(IItemGroupServiсe itemGroupService)
        {
            this.itemGroupService = itemGroupService;
        }


        public IActionResult Index()
        {
            var res = itemGroupService.GetAll();
            return View();
        }
    }
}
