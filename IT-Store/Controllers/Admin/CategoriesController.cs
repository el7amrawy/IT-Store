using IT_Store.Models;
using IT_Store.Repositories.Interfaces;
using IT_Store.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace IT_Store.Controllers.Admin
{
	[Route("Admin/{controller}/{action=Index}/{id?}")]
	public class CategoriesController : Controller
	{
		private readonly ICategoryRepository _repository;

		public CategoriesController(ICategoryRepository repository)
		{
			_repository = repository;
		}
		[HttpGet]
		public IActionResult Index()
		{
			TempData["AdminTabs"] = AdminTabs.Categories.ToString();
			return View("~/Views/Admin/Categories/Index.cshtml",_repository.GetAllWithParentCategory());
		}
		[HttpGet]
		public IActionResult Add([FromServices] IParentCategoryRepository rep) {
			var parentCategories = rep.GetAll();
			ViewBag.ParentCategories = new SelectList(parentCategories, "CategoryId","Name");
			return View("~/Views/Admin/Categories/Add.cshtml");
		}
        [HttpPost]
        public IActionResult Add(ViewModel_AddCategory model)
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
            return View("~/Views/Admin/Categories/Add.cshtml");
        }
		[HttpGet]
        public IActionResult Details(int id)
        {
            return View("~/Views/Admin/Categories/Details.cshtml", _repository.GetByIdWithParentCategory(id));
        }
        [HttpGet]
        public IActionResult Edit(int id, [FromServices] IParentCategoryRepository rep)
        {
			var parentCategories = rep.GetAll();
			ViewBag.ParentCategories = new SelectList(parentCategories, "CategoryId", "Name");
			return View("~/Views/Admin/Categories/Edit.cshtml", _repository.GetById(id));
        }
        [HttpPost]
        public IActionResult Edit(Category category)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _repository.Update(category);
                    _repository.Save();
                    return RedirectToAction("Details", new { id = category.CategoryId });
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", ex.Message);
                }
            }
            return RedirectToAction("Edit", new { id = category.CategoryId });
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            try
            {
                _repository.Delete(id);
                _repository.Save();
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Failed to delete the category");
            }
            return RedirectToAction("Index");
        }
    }
}
