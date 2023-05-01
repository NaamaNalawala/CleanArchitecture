using System;

namespace RentalQuotationModule.Core.Entities
{
    public class Todo: BaseEntity
    {
        public string Title { get; set; }
        public bool IsCompleted { get; set; }
    }
}
