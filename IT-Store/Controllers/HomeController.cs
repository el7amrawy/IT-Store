using IT_Store.Models;
using IT_Store.Repositories.Interfaces;
using IT_Store.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace IT_Store.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index([FromServices] IProductRepository productRep)
        {
            var products = productRep.GetAllWithCategory(1, 5);

			var model = new ViewModel_IndexHome(products);
            return View(model);
        }
        public IActionResult Store()
        {
            return View();
        }
    }
}