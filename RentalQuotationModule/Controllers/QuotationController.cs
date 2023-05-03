using Microsoft.AspNetCore.Mvc;

namespace RentalQuotationModule.Controllers
{
    public class QuotationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
