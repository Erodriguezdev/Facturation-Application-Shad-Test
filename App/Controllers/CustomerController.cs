using Facturation_Application_Schad___Test.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Services.Interfaces;
using Shared;
using System.Diagnostics;

namespace Facturation_Application_Schad___Test.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ILogger<CustomerController> _logger;
        private readonly ICustomer _customer;
        private readonly ItypeCustomer _typeCustomer;


        public CustomerController(ILogger<CustomerController> logger, ItypeCustomer typeCustomer, ICustomer customer)
        {
            _logger = logger;
            _typeCustomer = typeCustomer;
            _customer = customer;
        }


        public async Task<IActionResult> Customers()
        {
            ViewData["CustomerS"] = await _customer.getCustomersAsync("");
            return View(ViewData);
        }

        public IEnumerable<TypeCustomerModel> CustomerTypesModel { get; set; }

        public async Task<IActionResult> CustomerTypes()
        {
            ViewData["TypeCustomer"] = await _typeCustomer.GetTypeCustomerAsync("");

            return View(ViewData);
        }
        public async Task<IActionResult> AddCustomer()
        {
            ViewData["typeCustomer"] = await _typeCustomer.GetTypeCustomerAsync("");
            return View();
        }
        [BindProperty]
        public CustomerModel customer { get; set; }
        public async Task<IActionResult> PostPutCostumer()
        {
         
            if (customer.Id == 0)
            {
                int result = await _customer.CreateCustomer(customer);
                if (result == 0)
                {
                    return Redirect("AddCustomer");
                }
                else
                {
                    return Redirect("Customers");
                }
            }
            else
            {
                int result = await _customer.UpdateCustomer(customer);
                if (result == 0)
                {
                    return Redirect("AddCustomer");
                }
                else
                {
                    return Redirect("Customers");
                }
            }
        }
        public async Task<IActionResult> ModifyCustomer(int itemid)
        {

            var typeCustomerModel = await _customer.getCustomerByIdAsync(itemid);
            ViewData["typeCustomer"] = await _typeCustomer.GetTypeCustomerAsync("");
            return View(typeCustomerModel);
        }

        public IActionResult AddCustomerType()
        {
            return View();
        }
        public async Task<IActionResult> ModifyCustomerType(int itemid)
        {
            ViewData["typeCustomer"] = await _typeCustomer.GetTypeCustomerAsync("");
            TypeCustomerModel typeCustomerModel = await _typeCustomer.GetByIdAsync(itemid);

            return View(typeCustomerModel);
        }

        [BindProperty]
        public TypeCustomerModel TypeCustomerModel { get; set; }
        public async Task<IActionResult> postCustomerType()
        {
            if (!ModelState.IsValid)
            {
                return Redirect("AddCustomerType");
            }
            if (TypeCustomerModel.Id == 0)
            {
                int result = await _typeCustomer.CreateTypeCustomerAsync(TypeCustomerModel);
                if (result == 0)
                {
                    return Redirect("AddCustomerType");
                }
                else
                {
                    return Redirect("CustomerTypes");
                }
            }
            else
            {
                int result = await _typeCustomer.UpdateTypeCustomerAsync(TypeCustomerModel);
                if (result == 0)
                {
                    return Redirect("AddCustomerType");
                }
                else
                {
                    return Redirect("CustomerTypes");
                }

            }
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}