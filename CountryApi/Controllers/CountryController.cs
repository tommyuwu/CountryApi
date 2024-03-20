using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    public class CountryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
