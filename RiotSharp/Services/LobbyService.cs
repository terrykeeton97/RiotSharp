using Newtonsoft.Json;
using RiotSharp.Constants;
using RiotSharp.Enums;
using RiotSharp.Utilities;

namespace RiotSharp.Services
{
    public class LobbyService : ILobby
    {
        private readonly HttpClientFactory _httpClientFactory;

        public LobbyService()
        {
            _httpClientFactory = HttpClientFactory.Instance;
        }

        public async Task CreateLobbyAsync(QueueId queueId)
        {
            var body = new { queueId = (int)queueId };
            using var response = await _httpClientFactory.PostAsync(ApiEndpoints.CreateLobby, body);
            response.EnsureSuccessStatusCode();
        }

        public async Task QueueAsync(QueueType queueType)
        {
            using var response = await _httpClientFactory.PostAsync(ApiEndpoints.StartMatchmaking);
            response.EnsureSuccessStatusCode();
        }

        public async Task AcceptQueueAsync()
        {
            using var response = await _httpClientFactory.GetAsync(ApiEndpoints.ReadyCheck);
            response.EnsureSuccessStatusCode();
        }

        public async Task SelectRoleAsync(string? primaryRole, string? secondaryRole)
        {
            var body = new
            {
                firstPreference = primaryRole,
                secondPreference = secondaryRole,
            };

            using var response = await _httpClientFactory.PutAsync(ApiEndpoints.SelectRole, body);
            response.EnsureSuccessStatusCode();
        }
    }
}
