using System.Net.Mime;
using System.Text;
using System.Text.Json;
using AutoMapper;
using Chinook.DataStore.SqlServer;
using Chinook.Service.Configuration;
using Chinook.Service.Models.EasyPost;

namespace Chinook.Service
{
    public class EasyPostService : IShipmentService
    {
        private readonly IMapper _mapper;
        private readonly HttpClient _httpClient;

        public EasyPostService(IMapper mapper,IHttpClientFactory httpClient)
        {
            _mapper = mapper;
            //Typed Client would be easier to manage at scale.
            _httpClient = httpClient.CreateClient("EasyPostHttpClient");
        }

        public async Task<List<CustomerShippingRate>> EstimateShipmentCost(Customer fromCustomer, Customer toCustomer, CancellationToken? cancellationToken = null)
        {
            var shipment = new Shipment()
            {
                FromAddress =_mapper.Map<Address>(fromCustomer),
                ToAddress =_mapper.Map<Address>(toCustomer),
                //All "Tracks" being sold are shipped in the same size box and are of equal weight. :)
                Parcel = new()
                {
                    Length = 8,
                    Width = 6,
                    Height = 5,
                    Weight = 10
                }
            };

            //JsonContent was not working after needing to inspect HTTP call with Fiddler.
            var content = new StringContent(JsonSerializer.Serialize(new { shipment }, JsonSerializerConfig.JsonSerializerOptions), Encoding.UTF8, MediaTypeNames.Application.Json);
            //the EasyPost HttpClient can be abstracted some more
            var responseMessage = await _httpClient.PostAsync("/api/v2/shipments", content, cancellationToken ?? CancellationToken.None);
            responseMessage.EnsureSuccessStatusCode();

            var result = await JsonSerializer.DeserializeAsync<Shipment>(await responseMessage.Content.ReadAsStreamAsync(), JsonSerializerConfig.JsonSerializerOptions);
            
            return _mapper.Map<List<CustomerShippingRate>>(result?.Rates);
        }
    }
}