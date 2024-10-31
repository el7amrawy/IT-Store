using IT_Store.Models;
using IT_Store.Repositories.Interfaces;
using IT_Store.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IT_Store.Controllers.Admin
{
    [Route("Admin/[controller]/{action=Index}/{id?}")]
    [Authorize(Roles ="Admin")]
    public class ProductAttributesController : Controller
    {
        private readonly IProductAttributeRepository _productAttributeRep;

		public ProductAttributesController(IProductAttributeRepository productAttributeRep)
		{
			_productAttributeRep = productAttributeRep;
		}

		public IActionResult Index()
        {
            TempData["AdminTabs"]=AdminTabs.ProductAttributes.ToString();
            return View("~/Views/Admin/ProductAttributes/Index.cshtml",_productAttributeRep.GetAll());
        }
        [HttpGet]
        public IActionResult Add() {
            return View("~/Views/Admin/ProductAttributes/Add.cshtml");
        }
		[HttpPost]
		public IActionResult Add(ViewModel_AddProductAttribute model)
		{
            if (ModelState.IsValid) {
                var attribute = model.CreateProductAttribute();
                _productAttributeRep.Add(attribute);
                _productAttributeRep.Save();
                return RedirectToAction("Index");
            }
            return View("~/Views/Admin/ProductAttributes/Add.cshtml");
		}
        [HttpGet]
        public IActionResult Delete(int id) {
            _productAttributeRep.Delete(id);
            _productAttributeRep.Save();
            return RedirectToAction("Index");
        }
	}
}
