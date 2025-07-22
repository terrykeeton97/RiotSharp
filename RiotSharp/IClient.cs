using RiotSharp.Models;

namespace RiotSharp
{
    public interface IClient
    {
        Task<List<SearchState.Root?>> GetSearchStateAsync();
        Task<List<Invites.Invite>?> GetInvitesAsync();
        Task AcceptInviteAsync(string inviteId);
        Task<List<GameQueues.Root>> GetGameQueuesAsync();
        Task<List<ClientErrors>> GetAllClientErrorsAsync();
        Task<string?> RemoveClientErrorById(int? id);
    }
}
