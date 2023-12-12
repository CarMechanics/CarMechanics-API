using Microsoft.AspNetCore.Mvc;

namespace ProiectColectiv.Controllers
{
    public class AppointmentsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
