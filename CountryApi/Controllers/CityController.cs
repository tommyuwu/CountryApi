using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    public class CityController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
