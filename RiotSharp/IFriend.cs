using RiotSharp.Models;

namespace RiotSharp
{
    public interface IFriend
    {
        Task AcceptAllFriendRequestAsync(List<FriendRequest?> friendRequests);
        Task AcceptFriendRequestAsync(string? puuid);
        Task<List<FriendRequest?>> GetFriendRequestsAsync();
        Task<List<Friends>?> GetCurrentFriendsListAsync();
        Task InviteFriendAsync(string summonerId);
        Task<List<BlockedSummoners>?> GetBlockedSummonersAsync();
        Task<string?> UnblockPlayerByIdAsync(string? blockedSummonerId);
    }
}
