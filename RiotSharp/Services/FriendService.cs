using Newtonsoft.Json;
using RiotSharp.Enums;
using RiotSharp.Interfaces;
using RiotSharp.Models;
using RiotSharp.Utilities;

namespace RiotSharp.Services
{
    public class FriendService(HttpClientFactory httpClientFactory) : IFriendService
    {
        public async Task<List<FriendRequest?>> GetFriendRequests()
        {
            return await httpClientFactory.MakeApiRequest<List<FriendRequest?>>(RequestMethod.Get, $"/lol-chat/v2/friend-requests");
        }

        public async Task AcceptAllFriendRequestAsync(List<FriendRequest?> friendRequests)
        {
            foreach (var friend in friendRequests)
            {
                var body = new { direction = "both" };
                var jsonBody = JsonConvert.SerializeObject(body);
                await httpClientFactory.MakeApiRequest<string>(RequestMethod.Put, $"/lol-chat/v2/friend-requests/{friend.Puuid}", jsonBody);
            }
        }

        public async Task AcceptFriendRequestAsync(string? puuid)
        {
            var body = new { direction = "both" };
            var jsonBody = JsonConvert.SerializeObject(body);
            await httpClientFactory.MakeApiRequest<string>(RequestMethod.Put, $"/lol-chat/v2/friend-requests/{puuid}", jsonBody);
        }

        public async Task<List<Friends>?> GetCurrentFriendsListAsync()
        {
            return await httpClientFactory.MakeApiRequest<List<Friends>?>(RequestMethod.Get, "/lol-chat/v1/friends");
        }

        public Task InviteFriendAsync(string summonerId)
        {
            throw new NotImplementedException();
        }
    }
}