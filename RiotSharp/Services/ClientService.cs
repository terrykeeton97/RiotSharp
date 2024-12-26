using Newtonsoft.Json;
using RiotSharp.Enums;
using RiotSharp.Interfaces;
using RiotSharp.Models;
using RiotSharp.Utilities;

namespace RiotSharp.Services
{
    public class ClientService(HttpClientFactory httpClientFactory) : IClientService
    {
        public async Task<List<SearchState.Root?>> GetSearchState()
        {
            var response = await httpClientFactory.MakeApiRequest(RequestMethod.Get, "/lol-lobby/v2/lobby/matchmaking/search-state");
            return JsonConvert.DeserializeObject<List<SearchState.Root>?>(response);
        }

        public async Task<List<Invites.Invite>?> GetInvites()
        {
            var response = await httpClientFactory.MakeApiRequest(RequestMethod.Get, "/lol-lobby/v2/received-invitations");
            return JsonConvert.DeserializeObject<List<Invites.Invite?>>(response);
        }

        public async Task AcceptInviteAsync(string inviteId)
        {
            await httpClientFactory.MakeApiRequest(RequestMethod.Post, $"/lol-lobby/v2/received-invitations/{inviteId}/accept");
        }
    }
}