using Microsoft.AspNetCore.Mvc;

namespace InstitutionProject.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
