using Newtonsoft.Json;
using RiotSharp.Constants;
using RiotSharp.Enums;
using RiotSharp.Models;
using RiotSharp.Utilities;
using System.Net.Http;

namespace RiotSharp.Services
{
    public class FriendService : IFriend
    {
        private readonly HttpClientFactory _httpClientFactory;

        public FriendService()
        {
            _httpClientFactory = HttpClientFactory.Instance;
        }

        public async Task AcceptAllFriendRequestAsync(List<FriendRequest?> friendRequests)
        {
            foreach (var friend in friendRequests)
            {
                var body = new { direction = "both" };
                using var response = await _httpClientFactory.PutAsync(string.Format(ApiEndpoints.AcceptFriendRequest, friend?.Puuid), body);
                response.EnsureSuccessStatusCode();
            }
        }

        public async Task AcceptFriendRequestAsync(string? puuid)
        {
            var body = new { direction = "both" };
            using var response = await _httpClientFactory.PutAsync(string.Format(ApiEndpoints.AcceptFriendRequest, puuid), body);
            response.EnsureSuccessStatusCode();
        }

        public async Task<List<FriendRequest?>> GetFriendRequestsAsync()
        {
            return await _httpClientFactory.GetAsync<List<FriendRequest?>>(ApiEndpoints.FriendRequests);
        }

        public async Task<List<Friends>?> GetCurrentFriendsListAsync()
        {
            return await _httpClientFactory.GetAsync<List<Friends>?>(ApiEndpoints.Friends);
        }

        public async Task InviteFriendAsync(string summonerId)
        {
            var body = new { toSummonerId = summonerId };
            using var response = await _httpClientFactory.PostAsync(ApiEndpoints.SendFriendRequest, body);
            response.EnsureSuccessStatusCode();
        }

        public async Task<List<BlockedSummoners>?> GetBlockedSummonersAsync()
        {
            return await _httpClientFactory.GetAsync<List<BlockedSummoners>?>(ApiEndpoints.BlockedPlayers);
        }

        public async Task<string?> UnblockPlayerByIdAsync(string? blockedSummonerId)
        {
            using var response = await _httpClientFactory.DeleteAsync(string.Format(ApiEndpoints.UnblockPlayer, blockedSummonerId));
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }
    }
}
