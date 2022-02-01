using Chinook.DataStore.SqlServer;

namespace Chinook.Service;

public interface IShipmentService
{
    public Task<List<CustomerShippingRate>> EstimateShipmentCost(Customer fromCustomer, Customer toCustomer,
        CancellationToken? cancellationToken = null);
}