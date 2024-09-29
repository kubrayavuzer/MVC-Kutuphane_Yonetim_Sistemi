using Microsoft.AspNetCore.Mvc;

namespace MVC_Kutuphane_Yonetim.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Contant()
        {

            return View();
        }

        public IActionResult Content()
        {

            return View();
        }
    }


}
