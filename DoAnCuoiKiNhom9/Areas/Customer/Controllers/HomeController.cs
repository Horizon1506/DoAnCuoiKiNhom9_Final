using Microsoft.AspNetCore.Mvc;

namespace DoAnCuoiKiNhom9.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
