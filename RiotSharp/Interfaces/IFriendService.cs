using RiotSharp.Models;

namespace RiotSharp.Interfaces
{
    public interface IFriendService
    {
        public Task AcceptAllFriendRequestAsync(List<FriendRequest?> friendRequests);

        public Task AcceptFriendRequestAsync(string? puuid);

        public Task<List<FriendRequest?>> GetFriendRequestsAsync();

        public Task<List<Friends>?> GetCurrentFriendsListAsync();

        public Task InviteFriendAsync(string summonerId);

        public Task<List<BlockedSummoners>?> GetBlockedSummonersAsync();

        public Task<string?> UnblockPlayerByIdAsync(string? blockedSummonerId);
    }
}
