using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Microsoft.AspNetCore.Http;
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
        public IActionResult AddEdit()
        {
            return View("CostDetailsAddEdit");
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CostDetails costDetails)
        {
            //var costDetails = JsonConvert.DeserializeObject<CostDetails>(jsonData);
            try
            {
                if (ModelState.IsValid)
                {
                    await _costDetailService.AddAsync(costDetails);
                    var savedDataIds = HttpContext.Session.GetString("CostDetailIds");
                    if (string.IsNullOrEmpty(savedDataIds))
                    {
                        // If this is the first saved data, create a new list with the current Id
                        savedDataIds = JsonConvert.SerializeObject(new List<int> { costDetails.Id });
                    }
                    else
                    {
                        // If there are already saved data, deserialize the JSON string to a list and add the current Id
                        var idsList = JsonConvert.DeserializeObject<List<int>>(savedDataIds);
                        idsList.Add(costDetails.Id);
                        savedDataIds = JsonConvert.SerializeObject(idsList);
                    }
                    HttpContext.Session.SetString("CostDetailIds", savedDataIds);
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (System.Exception ex)
            {
                throw;
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
