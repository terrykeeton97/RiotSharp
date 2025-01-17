using RiotSharp.Models;

namespace RiotSharp.Interfaces
{
    internal interface IClientService
    {
        public Task<List<SearchState.Root?>> GetSearchStateAsync();

        public Task<List<Invites.Invite>?> GetInvitesAsync();

        public Task AcceptInviteAsync(string inviteId);

        public Task<List<GameQueues.Root>> GetGameQueuesAsync();

        public Task<List<ClientErrors>> GetAllClientErrorsAsync();

        public Task<string?> RemoveClientErrorById(int? id);
    }
}