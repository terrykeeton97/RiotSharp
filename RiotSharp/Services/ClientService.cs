using RiotSharp.Constants;
using RiotSharp.Enums;
using RiotSharp.Models;
using RiotSharp.Utilities;

namespace RiotSharp.Services
{
    internal class ClientService(HttpClientFactory httpClientFactory) : IClientService
    {
        public async Task<List<SearchState.Root?>> GetSearchStateAsync()
        {
            // Ensure MakeApiRequest<T> is correctly defined as an async method
            return await httpClientFactory.MakeApiRequest<List<SearchState.Root?>>(RequestMethod.Get, ApiEndpoints.LobbySearchState);
        }

        public async Task<List<Invites.Invite>?> GetInvitesAsync()
        {
            return await httpClientFactory.MakeApiRequest<List<Invites.Invite?>>(RequestMethod.Get, ApiEndpoints.Invites);
        }

        public async Task AcceptInviteAsync(string inviteId)
        {
            await httpClientFactory.MakeApiRequest<string>(RequestMethod.Post, string.Format(ApiEndpoints.AcceptInvite, inviteId));
        }

        public async Task<List<GameQueues.Root>> GetGameQueuesAsync()
        {
            return await httpClientFactory.MakeApiRequest<List<GameQueues.Root>>(RequestMethod.Get, ApiEndpoints.GameQueues);
        }

        public async Task<List<ClientErrors>> GetAllClientErrorsAsync()
        {
            return await httpClientFactory.MakeApiRequest<List<ClientErrors>>(RequestMethod.Get, ApiEndpoints.ChatErrors);
        }

        //TODO needs fix
        public async Task<string?> RemoveClientErrorById(int? id)
        {
            return await httpClientFactory.MakeApiRequest<string?>(RequestMethod.Delete, string.Format(ApiEndpoints.RemoveError, id));
        }
    }
}
