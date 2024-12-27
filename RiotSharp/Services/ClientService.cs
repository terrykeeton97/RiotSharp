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
            // Ensure MakeApiRequest<T> is correctly defined as an async method
            return await httpClientFactory.MakeApiRequest<List<SearchState.Root?>>(RequestMethod.Get, "/lol-lobby/v2/lobby/matchmaking/search-state");
        }

        public async Task<List<Invites.Invite>?> GetInvites()
        {
            return await httpClientFactory.MakeApiRequest<List<Invites.Invite?>>(RequestMethod.Get, "/lol-lobby/v2/received-invitations");
        }

        public async Task AcceptInviteAsync(string inviteId)
        {
            await httpClientFactory.MakeApiRequest<string>(RequestMethod.Post, $"/lol-lobby/v2/received-invitations/{inviteId}/accept");
        }
    }
}