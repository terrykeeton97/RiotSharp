using Newtonsoft.Json;
using RiotSharp.Constants;
using RiotSharp.Enums;
using RiotSharp.Models;
using RiotSharp.Utilities;
using System.Net.Http;

namespace RiotSharp.Services
{
    internal class FriendService(HttpClientFactory httpClientFactory) : IFriendService
    {
        public async Task AcceptAllFriendRequestAsync(List<FriendRequest?> friendRequests)
        {
            foreach (var friend in friendRequests)
            {
                var body = new { direction = "both" };
                var jsonBody = JsonConvert.SerializeObject(body);
                await httpClientFactory.MakeApiRequest<string>(RequestMethod.Put, string.Format(ApiEndpoints.AcceptFriendRequest, friend?.Puuid), jsonBody);
            }
        }

        public async Task AcceptFriendRequestAsync(string? puuid)
        {
            var body = new { direction = "both" };
            var jsonBody = JsonConvert.SerializeObject(body);
            await httpClientFactory.MakeApiRequest<string>(RequestMethod.Put, string.Format(ApiEndpoints.AcceptFriendRequest, puuid), jsonBody);
        }

        public async Task<List<FriendRequest?>> GetFriendRequestsAsync()
        {
            return await httpClientFactory.MakeApiRequest<List<FriendRequest?>>(RequestMethod.Get, ApiEndpoints.FriendRequests);
        }

        public async Task<List<Friends>?> GetCurrentFriendsListAsync()
        {
            return await httpClientFactory.MakeApiRequest<List<Friends>?>(RequestMethod.Get, ApiEndpoints.Friends);
        }

        public async Task InviteFriendAsync(string summonerId)
        {
            var body = new { toSummonerId = summonerId };
            var jsonBody = JsonConvert.SerializeObject(body);
            await httpClientFactory.MakeApiRequest<string>(RequestMethod.Post, ApiEndpoints.SendFriendRequest, jsonBody);
        }

        public async Task<List<BlockedSummoners>?> GetBlockedSummonersAsync()
        {
            return await httpClientFactory.MakeApiRequest<List<BlockedSummoners>?>(RequestMethod.Get, ApiEndpoints.BlockedPlayers);
        }

        public async Task<string?> UnblockPlayerByIdAsync(string? blockedSummonerId)
        {
            return await httpClientFactory.MakeApiRequest<string?>(RequestMethod.Delete, string.Format(ApiEndpoints.UnblockPlayer, blockedSummonerId));
        }
    }
}
