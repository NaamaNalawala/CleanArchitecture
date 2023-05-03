using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RentalQuotationModule.Core.Entities;
using RentalQuotationModule.Core.Interfaces;
using RentalQuotationModule.Core.Services;
using RentalQuotationModule.Models;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentalQuotationModule.Controllers
{
    public class CostDetailsController : Controller
    {
        private readonly ICostDetailService _costDetailService;
        public CostDetailsController(ICostDetailService costDetailService)
        {
            _costDetailService = costDetailService;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CostDetails costDetails)
        {
            //var costDetails = JsonConvert.DeserializeObject<CostDetails>(jsonData);
            if (ModelState.IsValid)
            {
                await _costDetailService.AddAsync(costDetails);
                return RedirectToAction(nameof(Index));
            }
            return View(costDetails);
        }
        [HttpGet]
        public async Task<JsonResult> Get([DataSourceRequest] DataSourceRequest request)
        {
            // Get the data from your data source
           var result = await _costDetailService.GetAllAsync();

            // Convert the data to the format required by the Kendo UI grid
            // var result = data.ToDataSourceResult(request);

            //var data2 = data.Select(x => new
            //{
            //    x.Make,
            //    x.Model,
            //    x.Group,
            //    x.CheckinLocation,
            //    x.CheckoutLocation,
            //    x.NoOfVehicle,
            //    x.RentalSum,
            //    x.Remarks
            //}).ToList();
            //var totall = data2.Count();
            return Json(new { data= result, total= result.Count() }) ;
        }
        [HttpGet]
        public async Task<List<CostDetails>> GetCostDetails()
        {
            // Get the data from your data source
            var data = await _costDetailService.GetAllAsync();
            return data.ToList();
        }
    }


}
