using System.Net;
using System.Net.Http.Headers;
using System.Text;
using Microsoft.Extensions.DependencyInjection;

namespace Chinook.Service.Configuration
{
    public static class ConfigurationExtensions
    {
        public static IServiceCollection AddEasyPostHttpClient(this IServiceCollection services)
        {
            services.AddHttpClient("EasyPostHttpClient", client =>
            {
                client.BaseAddress = new Uri("https://www.easypost.com/",UriKind.Absolute);
                client.DefaultRequestHeaders.Add("Accept", "application/json");

                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
                    AuthenticationSchemes.Basic.ToString(),
                    Convert.ToBase64String(
                        Encoding.ASCII.GetBytes("EZTK0f230736b77e49da841c1f63ce243975QLq8yXMfZOe87do5IcuPXQ:")));
            });

            return services;
        }
    }
}
