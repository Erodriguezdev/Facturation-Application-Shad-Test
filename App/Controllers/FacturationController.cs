using Facturation_Application_Schad___Test.Models;
using Microsoft.AspNetCore.Mvc;
using Models.Facturation;
using Services.Interfaces;
using Shared;
using System.Diagnostics;
using System.IO.Pipelines;

namespace Facturation_Application_Schad___Test.Controllers
{
    public class FacturationController : Controller
    {
        private readonly ILogger<FacturationController> _logger;
        private readonly IFacturation _facturation;
        private readonly ICustomer _customer;
        private List<InvoiceDetailModel> _invoiceDetail = new List<InvoiceDetailModel>();


        public FacturationController(ILogger<FacturationController> logger, IFacturation facturation, ICustomer customer)
        {
            _logger = logger;
            _facturation = facturation;
            _customer = customer;

        }

        public async Task<IActionResult> Facturation()
        {
            ViewData["Invoice"] = await _facturation.getAllInvoiceAsync();
            return View(ViewData);
        }
        public async Task<IActionResult> AddInvoice()
        {
            ViewBag.Customer = await _customer.getCustomersAsync("");
            DetailModel detail = new DetailModel();
            InvoiceModel invoice = new InvoiceModel();
            
            
            Tuple<InvoiceModel, DetailModel, List<InvoiceDetailModel>> model = new Tuple<InvoiceModel, DetailModel, List< InvoiceDetailModel>>(invoice, detail, _invoiceDetail 
);
            
            return View(model);
        }






        [BindProperty]
        public DetailModel detail { get; set; }
        public async Task< IActionResult> addDetail()
        {

            if (detail.CustomerId == 0)
                return Redirect($"AddInvoice");


            int result = await _facturation.AddItemInvoiceByDetail(detail);


            return Redirect($"Modify?ItemId={result}");
        }

        public async Task<IActionResult> Modify(int ItemId)
        {

           DetailModel detail = new DetailModel();
           var invoice = await _facturation.getInvoiceByIdAsync(ItemId);
            ViewBag.Customer = await _customer.getCustomersAsync("");

            Tuple<InvoiceModel, DetailModel, List<InvoiceDetailModel>> model = new Tuple<InvoiceModel, DetailModel, List<InvoiceDetailModel>>(invoice, detail, _invoiceDetail
);
           
            return View(model);
        }

        public async Task<IActionResult> DeleteItemInvoice(int ItemId)
        {
           int result = await _facturation.DeleteItemInvoice(ItemId);
            return Redirect($"Modify?ItemId={result}");

        }

            public async Task<IActionResult> PreviewInvoice(int ItemId)
        {
            ViewData["Invoice"] = await _facturation.getInvoiceByIdAsync(ItemId);
            return View(ViewData);
        }
       

        [BindProperty]
        public InvoiceModel Invoice { get; set; }
        public async Task<IActionResult> PostInvoice()
        {
           int result = await _facturation.CreateAsync(Invoice);
            if (result == 0)
            {
                return Redirect("AddInvoice");
            }
            else
            {
                return Redirect("Facturation");
            }
        }

            [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}