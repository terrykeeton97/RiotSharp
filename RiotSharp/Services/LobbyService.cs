using Newtonsoft.Json;
using RiotSharp.Enums;
using RiotSharp.Interfaces;
using RiotSharp.Utilities;

namespace RiotSharp.Services
{
    public class LobbyService(HttpClientFactory httpClientFactory) : ILobbyService
    {
        public async Task CreateLobbyAsync(QueueId queueId)
        {
            await httpClientFactory.MakeApiRequest<string>(RequestMethod.Post, "/lol-lobby/v2/lobby", $"{{\"queueId\":{queueId}}}");
        }

        public async Task QueueAsync(QueueType queueType)
        {
            await httpClientFactory.MakeApiRequest<string>(RequestMethod.Post, "/lol-lobby/v2/lobby/matchmaking/search");
        }

        public async Task AcceptQueueAsync()
        {
            await httpClientFactory.MakeApiRequest<string>(RequestMethod.Get, "/lol-matchmaking/v1/ready-check/accept");
        }

        public async Task SelectRoleAsync(string? primaryRole, string? secondaryRole)
        {
            var body = new
            {
                firstPreference = primaryRole,
                secondPreference = secondaryRole,
            };

            var jsonBody = JsonConvert.SerializeObject(body);
            await httpClientFactory.MakeApiRequest<string>(RequestMethod.Put, "/lol-lobby/v1/lobby/members/localMember/position-preferences", jsonBody);
        }
    }
}