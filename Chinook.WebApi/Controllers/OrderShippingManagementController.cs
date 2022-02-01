using Chinook.DataStore.SqlServer;
using Chinook.Service.Models;
using MassTransit.Mediator;
using Microsoft.AspNetCore.Mvc;

namespace Chinook.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderShippingManagementController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrderShippingManagementController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IEnumerable<CustomerShippingRate>> GetShippingRate([FromQuery] int? fromCustomerId, [FromQuery] int? toCustomerId)
        {
            if (!fromCustomerId.HasValue)
            {
                throw new ArgumentNullException(nameof(fromCustomerId), "fromCustomerId must be provided");
            }
            if (!toCustomerId.HasValue)
            {
                throw new ArgumentNullException(nameof(toCustomerId), "toCustomerId must be provided");
            }

            var requestClient = _mediator.CreateRequestClient<CustomerShippingRateRequest>();
            var result = await requestClient.GetResponse<CustomerShippingRateResponse>(new CustomerShippingRateRequest
            {
                FromCustomerId = fromCustomerId.Value,
                ToCustomerId = toCustomerId.Value
            });
            return result.Message.ShippingRates;
        }
    }
}