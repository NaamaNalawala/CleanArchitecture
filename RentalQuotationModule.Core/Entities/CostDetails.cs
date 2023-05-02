namespace RentalQuotationModule.Core.Entities
{
    public class CostDetails: BaseEntity
    {
        public string Make { get; set; }
        public string Model { get; set; }
        public string Group { get; set; }
        public string CheckoutLocation { get; set; }
        public string CheckinLocation { get; set; }
        public int NoOfVehicle { get; set; }
        public int RentalSum { get; set; }
        public string Remarks { get; set; }
    }
}
