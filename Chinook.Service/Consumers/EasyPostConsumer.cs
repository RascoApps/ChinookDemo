using AutoMapper;
using Chinook.DataStore.SqlServer;
using Chinook.Service.Models;
using MassTransit;

namespace Chinook.Service.Consumers
{
    public class EasyPostConsumer : IConsumer<CustomerShippingRateRequest>
    {
        private readonly IShipmentService _easyPostService;
        private readonly ChinookContext _chinookContext;
        private readonly IMapper _mapper;

        public EasyPostConsumer(IShipmentService easyPostService, ChinookContext chinookContext, IMapper mapper)
        {
            _easyPostService = easyPostService;
            _chinookContext = chinookContext;
            _mapper = mapper;
        }

        public async Task Consume(ConsumeContext<CustomerShippingRateRequest> context)
        {
            var fromCustomer = await _chinookContext.Customers.FindAsync(context.Message.FromCustomerId);
            var toCustomer = await _chinookContext.Customers.FindAsync(context.Message.ToCustomerId);
            if (fromCustomer == null)
            {
                throw new NullReferenceException("fromCustomerId not found");
            }
            if (toCustomer == null)
            {
                throw new NullReferenceException("toCustomerId not found");
            }
            var customerShippingRates = await _easyPostService.EstimateShipmentCost(fromCustomer, toCustomer);
            var response = _mapper.Map<CustomerShippingRateResponse>(customerShippingRates);
            await context.RespondAsync(response);
        }
    }
}