using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalQuotationModule.Core.Entities
{
    public class CostComponent: BaseEntity
    {
        public int CostDetailId { get; set; }
        public string Accessories { get; set; }
        public int Quantity { get; set; }
        public float Amount { get; set; }

    }
}
