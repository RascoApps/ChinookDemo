using System.Text.Json;
using System.Threading.Tasks;
using Chinook.DataStore.SqlServer;
using Chinook.Service.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NUnit.Framework;

namespace Chinook.Service.Tests
{
    public class Tests
    {
        EasyPostService _easyPostServiceFixture = null!;

        [SetUp]
        public void Setup()
        {
            var hostBuilder = Host.CreateDefaultBuilder()
                .ConfigureServices(a => a.AddEasyPostHttpClient()
                    .AddAutoMapper(cfg => cfg.AddProfile<EasyPostAutoMapperProfile>())
                    .AddTransient<EasyPostService>());
                ;
            var host = hostBuilder.Build();

            _easyPostServiceFixture = host.Services.GetRequiredService<EasyPostService>();

        }

        [Test]
        public async Task Test1()
        {
            var fromCustomer = new Customer() { PostalCode = "33147" };
            var toCustomer = new Customer() { PostalCode = "80113" };
            var result = await _easyPostServiceFixture.EstimateShipmentCost(fromCustomer, toCustomer);
            Assert.IsNotEmpty(result);
            TestContext.WriteLine(JsonSerializer.Serialize(result, JsonSerializerConfig.JsonSerializerOptions));
        }
    }
}