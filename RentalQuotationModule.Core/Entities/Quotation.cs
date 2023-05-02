using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalQuotationModule.Core.Entities
{
    public class Quotation: BaseEntity
    {
        public string QuotationNumber { get; set; }
        public string Company { get; set; }
        public string Branch { get; set; }
        public string QuotationCategory { get; set; }
        public string Debitor { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime ExpiryDate { get; set; }
        public bool IsApproved { get; set; }
        public DateTime RentalStartDate { get; set; }
        public DateTime RentalEndDate { get; set; }
        public int RentalDuration { get; set; }
        public float TotalRentalCost { get; set; }
        public float TotalAdditionalCost { get; set; }
        public float TotalAmount { get; set; }
        public int TotalNoOfVehicles { get; set; }
    }
}
