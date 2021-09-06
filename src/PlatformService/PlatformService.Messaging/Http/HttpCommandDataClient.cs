using Microsoft.Extensions.Options;
using PlatformService.Messaging.Configuration;
using PlatformService.Persistence.Models;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace PlatformService.Messaging.Http
{
    public class HttpCommandDataClient : ICommandDataClient
    {
        private readonly HttpClient _httpClient;
        private readonly RabbitMqConfiguration _rabbitMqConfiguration;

        public HttpCommandDataClient
            (HttpClient httpClient, 
            IOptions<RabbitMqConfiguration> rabbitMqConfiguration)
        {
            _httpClient = httpClient;
            _rabbitMqConfiguration = rabbitMqConfiguration.Value;
        }
        

        public async Task SendPlatformToCommand(Platform platform)
        {
            var httpContent = new StringContent(JsonSerializer.Serialize(platform), Encoding.UTF8, "application/json");

            string url = $"{_rabbitMqConfiguration.Host}{_rabbitMqConfiguration.Path}";
            var response = await _httpClient.PostAsync(url, httpContent);

            if (response.IsSuccessStatusCode)
                System.Console.WriteLine("--> Sync POST to CommandService - OK!");

            else 
                System.Console.WriteLine("--> Sync POST to CommandService - FAIL!");
        }
    }
}
