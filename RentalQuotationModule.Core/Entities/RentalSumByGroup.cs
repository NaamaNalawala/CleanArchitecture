using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalQuotationModule.Core.Entities
{
    public class RentalSumByGroup : BaseEntity
    {
        public string NoOfDays { get; set; }
        public int GroupAAmount { get; set; }
        public int GroupBAmount { get; set; }
    }
}
