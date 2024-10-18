using IT_Store.Repositories.Interfaces;
using IT_Store.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace IT_Store.Controllers.Admin
{
	[Route("Admin/{controller}/{action=Index}/{id?}")]
	[Authorize(Roles = "Admin")]
	public class ProductsController : Controller
	{
		private readonly IProductRepository _repository;

		public ProductsController(IProductRepository repository)
		{
			_repository = repository;
		}
		[HttpGet]
		public IActionResult Index()
		{
			TempData["AdminTabs"] = AdminTabs.Products.ToString();
			return View("~/Views/Admin/Products/Index.cshtml", _repository.GetAll());
		}
		[HttpGet]
		public IActionResult Add([FromServices] IBrandRepository brandRep, [FromServices] ICategoryRepository categoryRep)
		{
			ViewData["Categories"] = new SelectList(categoryRep.GetAll(), "CategoryId", "Name");
			ViewData["Brands"] = new SelectList(brandRep.GetAll(), "BrandId", "Name");
			return View("~/Views/Admin/Products/Add.cshtml");
		}
		[HttpPost]
		public IActionResult Add(ViewModel_AddProduct model)
		{
			if (ModelState.IsValid)
			{
				try
				{
					var newProduct=model.CreateProduct();
					_repository.Add(newProduct);
					_repository.Save();
					return RedirectToAction("Index");
				}
				catch (Exception ex)
				{
					ModelState.AddModelError("",ex.Message);
				}
			}
			return View("~/Views/Admin/Products/Add.cshtml");
		}
		public IActionResult Delete(int id)
		{
			try
			{
				_repository.Delete(id);
				_repository.Save();
			}
			catch
			{
				ModelState.AddModelError("", "Failed to delete the product");
			}
			return RedirectToAction("Index");
		}
	}
}
