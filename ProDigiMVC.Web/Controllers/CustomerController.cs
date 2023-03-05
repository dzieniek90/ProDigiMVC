using AutoMapper.Configuration.Conventions;
using Microsoft.AspNetCore.Mvc;
using ProDigiMVC.Application.Interfaces;
using ProDigiMVC.Application.ViewModels.Customer;

namespace ProDigiMVC.Web.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerService  _custService;
        public CustomerController(ICustomerService custService)
        {
            _custService = custService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var model = _custService.GetAllCustomersForList(2,1,"");
            return View(model);
        }

        [HttpPost]
        public IActionResult Index(int pageSize, int? pageNo, string searchString)
        {
            if (!pageNo.HasValue)
            {
                pageNo = 1;
            }
            if (searchString == null)
            {
                searchString = String.Empty;
            }
            var model = _custService.GetAllCustomersForList(pageSize, pageNo.Value, searchString);
            return View(model);
        }

        public IActionResult ViewCustomer(int id)
        {
            var customer = _custService.GetCustomerDetails(id);
            return View(customer);
        }
        [HttpGet]
        public IActionResult AddCustomer()
        {
            return View(new NewCustomerVm());
        }
        [HttpPost]
        public IActionResult AddCustomer(NewCustomerVm model)
        {
            var id = _custService.AddCustomer(model);
            return RedirectToAction("Index");
        }
    }
}
