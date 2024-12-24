using RiotSharp.Models;

namespace RiotSharp.Interfaces
{
    internal interface IFriendService
    {
        public Task AcceptAllFriendRequestAsync(List<FriendRequest?> friendRequests);

        public Task AcceptFriendRequestAsync(string? puuid);

        public Task<List<FriendRequest?>> GetFriendRequests();

        public Task<List<Friends>?> GetCurrentFriendsListAsync();

        public Task InviteFriendAsync(string summonerId);
    }
}