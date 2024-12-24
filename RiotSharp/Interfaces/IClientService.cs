using RiotSharp.Models;

namespace RiotSharp.Interfaces
{
    internal interface IClientService
    {
        public Task<List<SearchState.Root?>> GetSearchState();

        public Task<List<Invites.Invite>?> GetInvites();

        public Task AcceptInviteAsync(string inviteId);
    }
}