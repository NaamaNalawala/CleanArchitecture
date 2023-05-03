using Kendo.Mvc.UI;
using Microsoft.AspNetCore.Mvc;
using RentalQuotationModule.Core.Entities;
using RentalQuotationModule.Core.Interfaces;
using RentalQuotationModule.Core.Services;
using System.Linq;
using System.Threading.Tasks;

namespace RentalQuotationModule.Controllers
{
    public class QuotationController : Controller
    {
        private readonly IQuotationService _quotationService;
        public QuotationController(IQuotationService quotationService)
        {
            _quotationService = quotationService;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Create()
        {
            return View("QuotationCreate");
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Quotation quotation)
        {
            //var costDetails = JsonConvert.DeserializeObject<CostDetails>(jsonData);
            if (ModelState.IsValid)
            {
                await _quotationService.AddAsync(quotation);
                return RedirectToAction(nameof(Index));
            }
            return View(quotation);
        }
        [HttpGet]
        public async Task<JsonResult> Get([DataSourceRequest] DataSourceRequest request)
        {
            // Get the data from your data source
            var result = await _quotationService.GetAllAsync();

            return Json(new { data = result, total = result.Count() });
        }
    }
}
