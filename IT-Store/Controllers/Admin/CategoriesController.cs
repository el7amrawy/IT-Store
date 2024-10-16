using IT_Store.Repositories.Interfaces;
using IT_Store.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace IT_Store.Controllers.Admin
{
	[Route("Admin/{controller}/{action=Index}")]
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
			return View("~/Views/Admin/Categories/Index.cshtml",_repository.GetAll());
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
				}
				catch (Exception ex)
				{
					ModelState.AddModelError("Name", ex.Message);
				}
			}
            return View("~/Views/Admin/Categories/Add.cshtml");
        }
    }
}
