using RentalQuotationModule.Core.Entities;

namespace RentalQuotationModule.Models
{
    public class QuotationViewModel:Quotation
    {
        public string Name { get; set; }
        public string Category { get; set; }
        public string Email { get; set; }
        public string IDType { get; set; }
        public string IDNumber { get; set; }
        public string AddressLine { get; set; }
        public string Nationality { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }
    }
}
