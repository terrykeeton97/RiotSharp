using RiotSharp.Constants;
using RiotSharp.Enums;
using RiotSharp.Models;
using RiotSharp.Utilities;

namespace RiotSharp.Services
{
    public class RiotService : IRiot
    {
        private readonly HttpClientFactory _httpClientFactory;

        public RiotService()
        {
            _httpClientFactory = HttpClientFactory.Instance;
        }

        public async Task<Settings.Root> GetSettingsAsync()
        {
            return await _httpClientFactory.GetAsync<Settings.Root>(ApiEndpoints.GameSettings);
        }

        public async Task<string?> QuitClient()
        {
            using var response = await _httpClientFactory.PostAsync(ApiEndpoints.QuitClient);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }

        public async Task<string?> RestartUx()
        {
            using var response = await _httpClientFactory.PostAsync(ApiEndpoints.RestartUx);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }
    }
}
