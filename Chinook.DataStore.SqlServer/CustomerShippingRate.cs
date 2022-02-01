using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Chinook.DataStore.SqlServer
{

    public class CustomerShippingRate
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CustomerShippingRateId { get; init; }
        public string EasyPostRateId { get; init; } = null!;
        public Customer? Customer { get; init; } = null;
        public string? ZipCode => Customer?.PostalCode;
        public DateTime? CreatedAt { get; init; }
        public DateTime? UpdatedAt { get; init; }
        public string? Mode { get; init; }
        public string? Service { get; init; }
        public string? RateCost { get; init; }
        public string? ListRate { get; init; }
        public string? RetailRate { get; init; }
        public string? Currency { get; init; }
        public string? ListCurrency { get; init; }
        public string? RetailCurrency { get; init; }
        public int? EstDeliveryDays { get; init; }
        public DateTime? DeliveryDate { get; init; }
        public bool DeliveryDateGuaranteed { get; init; }
        public int DeliveryDays { get; init; }
        public string? Carrier { get; init; }
        public string? ShipmentId { get; init; }
        public string? CarrierAccountId { get; init; }
    }
}
