using Domain.Behaviors;
using Microsoft.Extensions.Options;
using System.Net.Http.Json;

namespace Infrastructure.Behaviors.Providers
{
    public sealed class IpClientService
    {
        private readonly string _baseURL;
        private readonly HttpClient _httpClient;

        public IpClientService(HttpClient httpClient, IOptions<Domain.Behaviors.Providers> options)
        {
            _httpClient = httpClient;
            _baseURL = options.Value.IPLocation;
        }

        public async Task<IpApiProviderResponse?> GetAsync(string? ipAddress, CancellationToken cancelationToken = default)
        {
            var route = $"{_baseURL}/json/{ipAddress}";
            _httpClient.DefaultRequestHeaders.Add("Accept", "application/json");

            var response = _httpClient.GetAsync(route, cancelationToken);
            var result = await response.Result.Content.ReadFromJsonAsync<IpApiProviderResponse>();

            return result;
        }
    }
}
