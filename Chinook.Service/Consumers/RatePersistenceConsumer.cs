using AutoMapper;
using Chinook.DataStore.SqlServer;
using Chinook.Service.Models;
using MassTransit;
using Microsoft.Extensions.Logging;

namespace Chinook.Service.Consumers
{
    public class RatePersistenceConsumer : IConsumer<CustomerShippingRateResponse>
    {
        private readonly ChinookContext _chinookContext;
        private readonly IMapper _mapper;
        private readonly ILogger<RatePersistenceConsumer> _logger;

        public RatePersistenceConsumer(ChinookContext chinookContext, IMapper mapper, ILogger<RatePersistenceConsumer> logger)
        {
            _chinookContext = chinookContext;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task Consume(ConsumeContext<CustomerShippingRateResponse> context)
        {
            var customerShippingRate = _mapper.Map<IEnumerable<CustomerShippingRate>>(context.Message.ShippingRates);


            foreach (var shippingRate in customerShippingRate)
            {
                shippingRate.FromCustomer = _mapper.Map<FromCustomer>(await _chinookContext.Customers.FindAsync(context.Message.FromCustomerId));
                shippingRate.ToCustomer = _mapper.Map<ToCustomer>(await _chinookContext.Customers.FindAsync(context.Message.ToCustomerId));
                _chinookContext.CustomerShippingRates.Add(shippingRate);
            }
            //Save not working due to EF Model
            //await _chinookContext.SaveChangesAsync();
            _logger.LogTrace("Saved CustomerRate for Shipping From CustomerId {FromCustomerId} To From CustomerId {ToCustomerId}", context.Message.FromCustomerId, context.Message.ToCustomerId);

        }
    }
}