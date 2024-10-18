using IT_Store.Models;
using IT_Store.Repositories.Interfaces;
using IT_Store.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace IT_Store.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductRepository _productRep;

		public HomeController(IProductRepository productRep)
		{
			_productRep = productRep;
		}
        [HttpGet]
		public IActionResult Index()
        {
			var model = new ViewModel_IndexHome(_productRep.GetAllWithCategory(1,7));
            return View(model);
        }
        [HttpGet]
        public IActionResult Store(int categoryId , int minPrice, int maxPrice, int brandId, int pageNumber, int pageSize,string searchTerm)
        {
            var model = new ViewModel_StoreHome
            {
                //Products = _productRep.FilterProducts(categoryId, minPrice, maxPrice, brandId, pageNumber),
                Products = _productRep.SearchAndFilter(searchTerm, categoryId, minPrice, maxPrice, brandId, pageNumber,pageSize=12),
                Count = _productRep.SearchedAndFilteredCount(searchTerm,categoryId, minPrice, maxPrice, brandId),
                PageSize= pageSize == 0 ? 10 : pageSize
            };
            return View(model);
        }
        [HttpGet]
        public IActionResult Products(int id) {
            return View(_productRep.GetByIdWithCategory(id));
        }
    }
}