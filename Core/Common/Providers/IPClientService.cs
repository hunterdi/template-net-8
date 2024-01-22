using Domain.Common;
using Microsoft.Extensions.Options;
using System.Net.Http.Json;

namespace Core.Common.Providers
{
    public sealed class IPClientService
    {
        private readonly string _baseURL;
        private readonly HttpClient _httpClient;

        public IPClientService(HttpClient httpClient, IOptions<Domain.Common.Providers> options)
        {
            _httpClient = httpClient;
            _baseURL = options.Value.IPLocation;
        }

        public async Task<IpApiProviderResponse?> GetAsync(string? ipAddress, CancellationToken cancelationToken = default)
        {
            var route = $"{_baseURL}/json/{ipAddress}";
            this._httpClient.DefaultRequestHeaders.Add("Accept", "application/json");

            //var response = await this._httpClient.GetFromJsonAsync<IpApiProviderResponse>(route, cancelationToken);

            var response = this._httpClient.GetAsync(route, cancelationToken);
            var result = await response.Result.Content.ReadFromJsonAsync<IpApiProviderResponse>();

            return result;
        }
    }
}
