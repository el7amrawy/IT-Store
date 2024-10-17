using IT_Store.Repositories.Interfaces;
using IT_Store.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace IT_Store.Controllers.Admin
{
	[Route("Admin/{controller}/{action=Index}")]
	public class ParentCategoriesController : Controller
	{
		private readonly IParentCategoryRepository _repository;

		public ParentCategoriesController(IParentCategoryRepository repository)
		{
			_repository = repository;
		}
		[HttpGet]
		public IActionResult Index()
		{
			TempData["AdminTabs"] = AdminTabs.ParentCategories.ToString();
			return View("~/Views/Admin/ParentCategories/Index.cshtml", _repository.GetAll());
		}
		[HttpGet]
		public IActionResult Add() {
			return View("~/Views/Admin/ParentCategories/Add.cshtml");
		}
        [HttpPost]
        public IActionResult Add(ViewModel_AddParentCategory model)
        {
			if (ModelState.IsValid) {
				try
				{
					var category=model.Category;
					_repository.Add(category);
					_repository.Save();
					return RedirectToAction("Index");
				}
				catch (Exception ex)
				{
					ModelState.AddModelError("Name", ex.Message);
				}
			}
            return View("~/Views/Admin/ParentCategories/Add.cshtml");
        }
    }
}
