using Chinook.DataStore.SqlServer;

namespace Chinook.Service.Models;

public record CustomerShippingRateRequest
{
    public int FromCustomerId { get; init; }
    public int ToCustomerId { get; init; }
}

public record CustomerShippingRateResponse
{
    public IEnumerable<CustomerShippingRate> ShippingRates { get; init; } = new HashSet<CustomerShippingRate>();
}