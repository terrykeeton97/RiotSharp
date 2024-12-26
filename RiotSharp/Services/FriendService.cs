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
            var response = await httpClientFactory.MakeApiRequest(RequestMethod.Get, $"/lol-chat/v2/friend-requests");
            return JsonConvert.DeserializeObject<List<FriendRequest?>>(response);
        }

        public async Task AcceptAllFriendRequestAsync(List<FriendRequest?> friendRequests)
        {
            foreach (var friend in friendRequests)
            {
                var body = new { direction = "both" };
                var jsonBody = JsonConvert.SerializeObject(body);
                await httpClientFactory.MakeApiRequest(RequestMethod.Put, $"/lol-chat/v2/friend-requests/{friend.Puuid}", jsonBody);
            }
        }

        public async Task AcceptFriendRequestAsync(string? puuid)
        {
            var body = new { direction = "both" };
            var jsonBody = JsonConvert.SerializeObject(body);
            await httpClientFactory.MakeApiRequest(RequestMethod.Put, $"/lol-chat/v2/friend-requests/{puuid}", jsonBody);
        }

        public async Task<List<Friends>?> GetCurrentFriendsListAsync()
        {
            var response = await httpClientFactory.MakeApiRequest(RequestMethod.Get, "/lol-chat/v1/friends");
            return JsonConvert.DeserializeObject<List<Friends>>(response);
        }

        public Task InviteFriendAsync(string summonerId)
        {
            throw new NotImplementedException();
        }
    }
}