namespace Chinook.Service.Models.EasyPost
{

    public class Shipment
    {
        public DateTime CreatedAt { get; set; }
        public bool? IsReturn { get; set; }
        public string? Mode { get; set; }
        public Options Options { get; set; }
        public string? Status { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public Address ToAddress { get; set; }
        public Address FromAddress { get; set; }
        public Parcel? Parcel { get; set; }
        public Rate[] Rates { get; set; }
        public int? UspsZone { get; set; }
        public ReturnAddress? ReturnAddress { get; set; }
        public BuyerAddress? BuyerAddress { get; set; }
        public string? Id { get; set; }
    }
}
