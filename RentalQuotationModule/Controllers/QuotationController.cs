using Kendo.Mvc.UI;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient.Server;
using RentalQuotationModule.Core.Entities;
using RentalQuotationModule.Core.Interfaces;
using RentalQuotationModule.Core.Services;
using RentalQuotationModule.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Threading.Tasks;

namespace RentalQuotationModule.Controllers
{
    public class QuotationController : Controller
    {
        private readonly IQuotationService _quotationService;
        private readonly ICustomerService _customerService;
        private readonly ICostDetailService _costDetailService;
        public QuotationController(IQuotationService quotationService, ICustomerService customerService, ICostDetailService costDetailService)
        {
            _quotationService = quotationService;
            _customerService = customerService;
            _costDetailService = costDetailService;
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
        public async Task<IActionResult> CreateQuotation(IFormCollection form)
        {
            try
            {
                var model = GetQuotationValueFromFormElement(form);
                if (ModelState.IsValid)
                {
                    Quotation quotation = new Quotation
                    {
                        QuotationNumber = model.QuotationNumber,
                        Company = model.Company,
                        Branch = model.Branch,
                        QuotationCategory = model.QuotationCategory,
                        Debitor = model.Debitor,
                        IssueDate = model.IssueDate,
                        ExpiryDate = model.ExpiryDate,
                        IsApproved = model.IsApproved,
                        RentalStartDate = model.RentalStartDate,
                        RentalEndDate = model.RentalEndDate,
                        RentalDuration = model.RentalDuration,
                        TotalRentalCost = model.TotalRentalCost,
                        TotalAdditionalCost = model.TotalAdditionalCost,
                        TotalAmount = model.TotalAmount,
                        TotalNoOfVehicles = model.TotalNoOfVehicles
                    };
                    Customer customer = new Customer
                    {
                        Name = model.Name,
                        Category = model.Category,
                        Email = model.Email,
                        IDType = model.IDType,
                        IDNumber = model.IDNumber,
                        AddressLine = model.AddressLine,
                        Nationality = model.Nationality,
                        Country = model.Country,
                        Phone = model.Phone
                    };
                    await _quotationService.AddAsync(quotation);
                    quotation.QuotationNumber = "QTN-" + quotation.IssueDate.Day+"" + quotation.IssueDate.Year+"" + quotation.Id;
                    await _quotationService.UpdateAsync(quotation);
                    customer.QuotationId = quotation.Id;
                    await _customerService.AddAsync(customer);
                    //Get all the saved cost details Id
                    var savedCostDetailsId = HttpContext.Session.GetString("CostDetailIds");
                    if (!string.IsNullOrEmpty(savedCostDetailsId))
                    {
                        // Convert the comma-separated string of ids to a list of integers
                        List<int> costDetailIds = savedCostDetailsId.Split(',').Select(int.Parse).ToList();

                        // Filter the addedCosts collection based on the list of ids
                        var addedCosts = await _costDetailService.GetAllAsync();
                        addedCosts = addedCosts.Where(x => costDetailIds.Contains(x.Id)).ToList();
                        foreach (var item in addedCosts)
                        {
                            item.QuotationId = quotation.Id;
                            await _costDetailService.UpdateAsync(item);
                        }

                    }
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return View("Index");
        }
        [HttpGet]
        public async Task<JsonResult> Get([DataSourceRequest] DataSourceRequest request)
        {
            // Get the data from your data source
            var result = await _quotationService.GetAllAsync();
            return Json(new { data = result, total = result.Count() });
        }
        private QuotationViewModel GetQuotationValueFromFormElement([FromBody] IFormCollection form)
        {
            var quotationViewModel = new QuotationViewModel();

            var name = form["Name"];
            var email = form["Email"];
            var category = form["Category"];
            var idType = form["IDType"];
            var idNumber = form["IDNumber"];
            var addressLine = form["AddressLine"];
            var nationality = form["Nationality"];
            var country = form["Country"];
            var phone = form["Phone"];
            var company = form["Company"];
            var branch = form["Branch"];
            var quotationCategory = form["QuotationCategory"];
            var debitor = form["Debitor"];
            var issueDate = form["IssueDate"];
            var expiryDate = form["ExpiryDate"];

            var rentalStartDate = form["RentalStartDate"];
            var rentalEndDate = form["RentalEndDate"];
            var rentalDuration = form["RentalDuration"];
            var totalRentalCost = form["TotalRentalCost"];
            var totalAdditionalCost = form["TotalAdditionalCost"];
            var totalAmount = form["TotalAmount"];
            var totalNoOfVehicles = form["TotalNoOfVehicles"];

            quotationViewModel.QuotationCategory= quotationCategory;
            quotationViewModel.Branch= branch;
            quotationViewModel.Company= company;
            quotationViewModel.QuotationCategory = quotationCategory;
            quotationViewModel.Name = name;
            quotationViewModel.Email = email;
            quotationViewModel.Category = category;
            quotationViewModel.IDType = idType;
            quotationViewModel.IDNumber = idNumber;
            quotationViewModel.AddressLine = addressLine;
            quotationViewModel.Nationality = nationality;
            quotationViewModel.Country = country;
            quotationViewModel.Phone = phone;
            quotationViewModel.Debitor = debitor;
            quotationViewModel.IssueDate = DateTime.Parse(issueDate);
            quotationViewModel.ExpiryDate = DateTime.Parse(expiryDate[0].Split(',')[0]);

            // Set values to the reservation object
            quotationViewModel.RentalStartDate = DateTime.Parse(rentalStartDate);
            quotationViewModel.RentalEndDate = DateTime.Parse(rentalEndDate);
            quotationViewModel.RentalDuration = int.Parse(rentalDuration);
            quotationViewModel.TotalRentalCost = (float)decimal.Parse(totalRentalCost);
            quotationViewModel.TotalAdditionalCost = (float)decimal.Parse(totalAdditionalCost);
            quotationViewModel.TotalAmount = (float)decimal.Parse(totalAmount);
            quotationViewModel.TotalNoOfVehicles = int.Parse(totalNoOfVehicles);

            return quotationViewModel;
        }

    }
}
