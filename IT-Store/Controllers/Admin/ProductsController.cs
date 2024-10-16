using IT_Store.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace IT_Store.Controllers.Admin
{
	[Route("Admin/{controller}/{action=Index}")]
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
			return View("~/Views/Admin/Products/Index.cshtml",_repository.GetAll());
		}
		[HttpGet]
		public IActionResult Add() {
			return View("~/Views/Admin/Products/Add.cshtml");
		}
	}
}
