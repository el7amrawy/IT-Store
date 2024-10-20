using IT_Store.Models;
using IT_Store.Repositories.Interfaces;
using IT_Store.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IT_Store.Controllers.Account
{
    [Authorize(Roles = "User")]
    [Route("Account/{controller}/{action=Index}/{id?}")]
    public class AddressesController : Controller
    {
        private readonly IAddressRepository _addressRep;

        public AddressesController(IAddressRepository addressRep)
        {
            _addressRep = addressRep;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View(_addressRep.GetByUserId(this.GetUserId()));
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(ViewModel_AddAddress model)
        {
            if (ModelState.IsValid) { 
                Address address=model.CreateAddress(this.GetUserId());
                _addressRep.Add(address);
                _addressRep.Save();
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            try
            {
                _addressRep.Delete(id);
                _addressRep.Save();
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Failed to delete the address");
            }
            return RedirectToAction("Index");
        }
    }
}
