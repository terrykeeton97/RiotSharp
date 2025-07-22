using RiotSharp.Constants;
using RiotSharp.Enums;
using RiotSharp.Models;
using RiotSharp.Utilities;

namespace RiotSharp.Services
{
    public class ClientService : IClient
    {
        private readonly HttpClientFactory _httpClientFactory;

        public ClientService()
        {
            _httpClientFactory = HttpClientFactory.Instance;
        }

        public async Task<List<SearchState.Root?>> GetSearchStateAsync()
        {
            return await _httpClientFactory.GetAsync<List<SearchState.Root?>>(ApiEndpoints.LobbySearchState);
        }

        public async Task<List<Invites.Invite>?> GetInvitesAsync()
        {
            return await _httpClientFactory.GetAsync<List<Invites.Invite>?>(ApiEndpoints.Invites);
        }

        public async Task AcceptInviteAsync(string inviteId)
        {
            using var response = await _httpClientFactory.PostAsync(string.Format(ApiEndpoints.AcceptInvite, inviteId));
            response.EnsureSuccessStatusCode();
        }

        public async Task<List<GameQueues.Root>> GetGameQueuesAsync()
        {
            return await _httpClientFactory.GetAsync<List<GameQueues.Root>>(ApiEndpoints.GameQueues);
        }

        public async Task<List<ClientErrors>> GetAllClientErrorsAsync()
        {
            return await _httpClientFactory.GetAsync<List<ClientErrors>>(ApiEndpoints.ChatErrors);
        }

        public async Task<string?> RemoveClientErrorById(int? id)
        {
            using var response = await _httpClientFactory.DeleteAsync(string.Format(ApiEndpoints.RemoveError, id));
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }
    }
}
