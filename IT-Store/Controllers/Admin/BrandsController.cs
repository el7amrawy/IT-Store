using IT_Store.Repositories.Interfaces;
using IT_Store.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace IT_Store.Controllers.Admin
{
	[Route("Admin/{controller}/{action=Index}")]
	public class BrandsController : Controller
	{
		private readonly IBrandRepository _repository;

		public BrandsController(IBrandRepository repository)
		{
			_repository = repository;
		}

		public IActionResult Index()
		{
			return View("~/Views/Admin/Brands/Index.cshtml",_repository.GetAll());
		}
		[HttpGet]
		public IActionResult Add()
		{
			return View("~/Views/Admin/Brands/Add.cshtml");
		}
		[HttpPost]
        public IActionResult Add(ViewModel_AddBrand model)
        {
			if (ModelState.IsValid) {
				try
				{
					var brand=model.Brand;
					_repository.Add(brand);
					_repository.Save();
					return RedirectToAction("Index");
				}
				catch (Exception ex)
				{
					ModelState.AddModelError("Name",ex.Message);
				}
			}
            return View("~/Views/Admin/Brands/Add.cshtml");
        }
    }
}
