using Newtonsoft.Json;
using RiotSharp.Constants;
using RiotSharp.Enums;
using RiotSharp.Utilities;

namespace RiotSharp.Services
{
    internal class LobbyService(HttpClientFactory httpClientFactory) : ILobbyService
    {
        public async Task CreateLobbyAsync(QueueId queueId)
        {
            await httpClientFactory.MakeApiRequest<string>(RequestMethod.Post, ApiEndpoints.CreateLobby, $"{{\"queueId\":{queueId}}}");
        }

        public async Task QueueAsync(QueueType queueType)
        {
            await httpClientFactory.MakeApiRequest<string>(RequestMethod.Post, ApiEndpoints.StartMatchmaking);
        }

        public async Task AcceptQueueAsync()
        {
            await httpClientFactory.MakeApiRequest<string>(RequestMethod.Get, ApiEndpoints.ReadyCheck);
        }

        public async Task SelectRoleAsync(string? primaryRole, string? secondaryRole)
        {
            var body = new
            {
                firstPreference = primaryRole,
                secondPreference = secondaryRole,
            };

            var jsonBody = JsonConvert.SerializeObject(body);
            await httpClientFactory.MakeApiRequest<string>(RequestMethod.Put, ApiEndpoints.SelectRole, jsonBody);
        }
    }
}
