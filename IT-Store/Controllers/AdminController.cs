using Microsoft.AspNetCore.Mvc;

namespace IT_Store.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Dashboard()
        {
            return View();
        }
    }
}
