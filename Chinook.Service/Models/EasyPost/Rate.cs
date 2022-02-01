using System.Text.Json.Serialization;

namespace Chinook.Service.Models.EasyPost;

public class Rate
{
    public string Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public string Mode { get; set; }
    public string Service { get; set; }
    public string Carrier { get; set; }

    [JsonPropertyName("Rate")]
    public string RateAmount { get; set; }
    public string Currency { get; set; }
    public string RetailRate { get; set; }
    public string RetailCurrency { get; set; }
    public string ListRate { get; set; }
    public string ListCurrency { get; set; }
    public int? DeliveryDays { get; set; }
    public DateTime? DeliveryDate { get; set; }
    public bool DeliveryDateGuaranteed { get; set; }
    public int? EstDeliveryDays { get; set; }
    public string ShipmentId { get; set; }
    public string CarrierAccountId { get; set; }
}