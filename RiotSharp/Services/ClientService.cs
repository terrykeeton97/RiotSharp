using RiotSharp.Enums;
using RiotSharp.Interfaces;
using RiotSharp.Models;
using RiotSharp.Utilities;

namespace RiotSharp.Services
{
    public class ClientService(HttpClientFactory httpClientFactory) : IClientService
    {
        public async Task<List<SearchState.Root?>> GetSearchStateAsync()
        {
            // Ensure MakeApiRequest<T> is correctly defined as an async method
            return await httpClientFactory.MakeApiRequest<List<SearchState.Root?>>(RequestMethod.Get, "/lol-lobby/v2/lobby/matchmaking/search-state");
        }

        public async Task<List<Invites.Invite>?> GetInvitesAsync()
        {
            return await httpClientFactory.MakeApiRequest<List<Invites.Invite?>>(RequestMethod.Get, "/lol-lobby/v2/received-invitations");
        }

        public async Task AcceptInviteAsync(string inviteId)
        {
            await httpClientFactory.MakeApiRequest<string>(RequestMethod.Post, $"/lol-lobby/v2/received-invitations/{inviteId}/accept");
        }

        public async Task<List<GameQueues.Root>> GetGameQueuesAsync()
        {
            return await httpClientFactory.MakeApiRequest<List<GameQueues.Root>>(RequestMethod.Get, "/lol-game-queues/v1/queues");
        }

        public async Task<List<ClientErrors>> GetAllClientErrorsAsync()
        {
            return await httpClientFactory.MakeApiRequest<List<ClientErrors>>(RequestMethod.Get, "/lol-chat/v1/errors");
        }

        //TODO needs fix
        public async Task<string?> RemoveClientErrorById(int? id)
        {
            return await httpClientFactory.MakeApiRequest<string?>(RequestMethod.Delete, $"/lol-chat/v1/errors/{id}");
        }
    }
}