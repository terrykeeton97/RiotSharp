using Newtonsoft.Json;
using RiotSharp.Enums;
using RiotSharp.Interfaces;
using RiotSharp.Models;
using RiotSharp.Utilities;
using System.Net.Http;

namespace RiotSharp.Services
{
    public class FriendService(HttpClientFactory httpClientFactory) : IFriendService
    {
        public async Task AcceptAllFriendRequestAsync(List<FriendRequest?> friendRequests)
        {
            foreach (var friend in friendRequests)
            {
                var body = new { direction = "both" };
                var jsonBody = JsonConvert.SerializeObject(body);
                await httpClientFactory.MakeApiRequest<string>(RequestMethod.Put, $"/lol-chat/v2/friend-requests/{friend?.Puuid}", jsonBody);
            }
        }

        public async Task AcceptFriendRequestAsync(string? puuid)
        {
            var body = new { direction = "both" };
            var jsonBody = JsonConvert.SerializeObject(body);
            await httpClientFactory.MakeApiRequest<string>(RequestMethod.Put, $"/lol-chat/v2/friend-requests/{puuid}", jsonBody);
        }

        public async Task<List<FriendRequest?>> GetFriendRequestsAsync()
        {
            return await httpClientFactory.MakeApiRequest<List<FriendRequest?>>(RequestMethod.Get, "/lol-chat/v2/friend-requests");
        }

        public async Task<List<Friends>?> GetCurrentFriendsListAsync()
        {
            return await httpClientFactory.MakeApiRequest<List<Friends>?>(RequestMethod.Get, "/lol-chat/v1/friends");
        }

        public async Task InviteFriendAsync(string summonerId)
        {
            var body = new { toSummonerId = summonerId };
            var jsonBody = JsonConvert.SerializeObject(body);
            await httpClientFactory.MakeApiRequest<string>(RequestMethod.Post, "/lol-chat/v1/friend-requests", jsonBody);
        }

        public async Task<List<BlockedSummoners>?> GetBlockedSummonersAsync()
        {
            return await httpClientFactory.MakeApiRequest<List<BlockedSummoners>?>(RequestMethod.Get, "/lol-chat/v1/blocked-players");
        }

        public async Task<string?> UnblockPlayerByIdAsync(string? blockedSummonerId)
        {
            return await httpClientFactory.MakeApiRequest<string?>(RequestMethod.Delete, $"/lol-chat/v1/blocked-players/{blockedSummonerId}");
        }
    }
}
