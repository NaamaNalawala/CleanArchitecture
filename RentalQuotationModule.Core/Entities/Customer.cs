using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalQuotationModule.Core.Entities
{
    public class Customer:BaseEntity
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
