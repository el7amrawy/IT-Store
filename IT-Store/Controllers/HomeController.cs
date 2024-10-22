using IT_Store.Models;
using IT_Store.Repositories.Interfaces;
using IT_Store.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace IT_Store.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductRepository _productRep;
        private readonly IBrandRepository _brandRep;
		public HomeController(IProductRepository productRep, IBrandRepository brandRep)
		{
			_productRep = productRep;
			_brandRep = brandRep;
		}
		[HttpGet]
		public IActionResult Index()
        {
			var model = new ViewModel_IndexHome(_productRep.GetAllWithCategory(1,7));
            return View(model);
        }
        [HttpGet]
		public IActionResult Store(int categoryId, int minPrice, int maxPrice, int brandId, int pageNumber, int pageSize, string searchTerm)
		{
			var model = new ViewModel_StoreHome
			{
				//Products = _productRep.FilterProducts(categoryId, minPrice, maxPrice, brandId, pageNumber),
				Products = _productRep.SearchAndFilter(searchTerm, categoryId, minPrice, maxPrice, brandId, pageNumber, pageSize = 12),
				Count = _productRep.SearchedAndFilteredCount(searchTerm, categoryId, minPrice, maxPrice, brandId),
				PageSize = pageSize == 0 ? 10 : pageSize,
				Brands = _brandRep.GetTop(5)
			};
			return View(model);
		}
		[HttpGet]
		public IActionResult StoreFilters(string categoryIds, int minPrice, int maxPrice, string brandIds, int pageNumber, int pageSize, string searchTerm) {
			
			List<int> categoryIdList=new List<int>();
			List<int> brandIdList=new List<int>();

			if (!string.IsNullOrWhiteSpace(categoryIds))
				categoryIdList = categoryIds.Split(',').ToListOfInt();

			if (!string.IsNullOrWhiteSpace(brandIds))
				brandIdList = brandIds.Split(',').ToListOfInt();

			var model = new ViewModel_StoreHome
			{
				//Products = _productRep.FilterProducts(categoryId, minPrice, maxPrice, brandId, pageNumber),
				Products = _productRep.SearchAndFilter(searchTerm,categoryIdList,brandIdList,minPrice,maxPrice,1, pageSize=12),
				Count = _productRep.SearchedAndFilteredCount(searchTerm,categoryIdList,brandIdList,minPrice,maxPrice),
				PageSize = pageSize == 0 ? 12 : pageSize,
				Brands = _brandRep.GetTop(5)
			};
			return View("~/Views/Home/Store.cshtml",model);
		}
        [HttpGet]
        public IActionResult Product(int id) {
            Product product = _productRep.GetByIdWithCategory(id);
			return View(new ViewModel_ProductHome { Product =product, RelatedProducts = _productRep.FilterProducts((int)product.CategoryId, pageSize: 3) });
        }
    }
}