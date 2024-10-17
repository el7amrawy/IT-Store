using IT_Store.Models;
using IT_Store.Repositories.Interfaces;
using IT_Store.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace IT_Store.Controllers.Admin
{
	[Route("Admin/{controller}/{action=Index}/{id?}")]
	public class BrandsController : Controller
	{
		private readonly IBrandRepository _repository;

		public BrandsController(IBrandRepository repository)
		{
			_repository = repository;
		}

		public IActionResult Index()
		{
			TempData["AdminTabs"] = AdminTabs.Brands.ToString();
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
		[HttpGet]
		public IActionResult Details(int id) {
			return View("~/Views/Admin/Brands/Details.cshtml",_repository.GetById(id));
		}
		[HttpGet]
		public IActionResult Edit(int id) { 
			return View("~/Views/Admin/Brands/Edit.cshtml",_repository.GetById(id));
		}
		[HttpPost]
		public IActionResult Edit(Brand brand)
		{
			if (ModelState.IsValid)
			{
				try
				{
					_repository.Update(brand);
					_repository.Save();
					return RedirectToAction("Details", new {id=brand.BrandId});
				}
				catch (Exception ex)
				{
					ModelState.AddModelError("", ex.Message);
				}
			}
			return Edit(brand.BrandId);
		}
		[HttpGet]
		public IActionResult Delete(int id) {
			try
			{
				_repository.Delete(id);
				_repository.Save();
			}
			catch (Exception)
			{
				ModelState.AddModelError("", "Failed to delete the brand");
			}
			return RedirectToAction("Index");
		}
    }
}
