using Newtonsoft.Json;
using RiotSharp.Enums;
using RiotSharp.Interfaces;
using RiotSharp.Models;
using RiotSharp.Utilities;

namespace RiotSharp.Services
{
    public class RiotApiClient : IRiotApiClient
    {
        private readonly HttpClientFactory _httpClient = new();

        public async Task<CurrentSession?> GetAccountSessionAsync()
        {
            var response = await _httpClient.MakeApiRequest(RequestMethod.Get, "/lol-login/v1/session");
            return JsonConvert.DeserializeObject<CurrentSession>(response)!;
        }

        public async Task<string?> GetUsernameAsync()
        {
            var response = await _httpClient.MakeApiRequest(RequestMethod.Get, "/lol-login/v1/session");

            var json = JsonConvert.DeserializeObject<dynamic>(response);
            return json.username;
        }

        public async Task<string?> GetSummonerId()
        {
            var response = await _httpClient.MakeApiRequest(RequestMethod.Get, "/lol-login/v1/session");

            var json = JsonConvert.DeserializeObject<dynamic>(response);
            return json.summonerId;
        }

        public async Task<List<Champions>>? GetAllChampionsAsync()
        {
            var account = await GetAccountSessionAsync();
            var response = await _httpClient.MakeApiRequest(RequestMethod.Get, $"/lol-champions/v1/inventories/{account.AccountId}/champions-minimal");
            return JsonConvert.DeserializeObject<List<Champions>>(response);
        }

        public Task<Rank?> GetRankAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<ChampionSelect?> GetChampionSelectAsync()
        {
            var response = await _httpClient.MakeApiRequest(RequestMethod.Get, "lol-champ-select/v1/session");
            return JsonConvert.DeserializeObject<ChampionSelect?>(response);
        }

        public async Task CreateLobby(QueueId queueId)
        {
            await _httpClient.MakeApiRequest(RequestMethod.Post, "/lol-lobby/v2/lobby", $"{{\"queueId\":{queueId}}}");
        }

        public async Task QueueAsync(QueueType queueType)
        {
            await _httpClient.MakeApiRequest(RequestMethod.Post, "/lol-lobby/v2/lobby/matchmaking/search");
        }

        public async Task HoverChampionAsync(int actionId, int championId)
        {
            await _httpClient.MakeApiRequest(RequestMethod.Patch, "/lol-champ-select/v1/session/actions/" + actionId, "{\"championId\":" + championId + "}");
        }

        public async Task SelectRoleAsync(string? firstRole, string? secondRole)
        {
            var body = new
            {
                firstPreference = firstRole,
                secondPreference = secondRole,
            };

            var jsonBody = JsonConvert.SerializeObject(body);
            await _httpClient.MakeApiRequest(RequestMethod.Put, "/lol-lobby/v1/lobby/members/localMember/position-preferences", jsonBody);
        }

        public async Task AcceptFriendRequestAsync(List<FriendRequest?> friendRequests)
        {
            foreach (var friend in friendRequests)
            {
                var body = new { direction = "both" };
                var jsonBody = JsonConvert.SerializeObject(body);
                await _httpClient.MakeApiRequest(RequestMethod.Put, $"/lol-chat/v2/friend-requests/{friend.Puuid}", jsonBody);
            }
        }

        public async Task<List<FriendRequest?>> GetFriendRequests()
        {
            var response = await _httpClient.MakeApiRequest(RequestMethod.Get, $"/lol-chat/v2/friend-requests");
            return JsonConvert.DeserializeObject<List<FriendRequest?>>(response);
        }

        /// <summary>
        /// Pass the friend request Puuid to accept the request
        /// </summary>
        /// <param name="puuid"></param>
        /// <returns></returns>
        public async Task AcceptFriendRequestAsync(string? puuid)
        {
            var body = new { direction = "both" };
            var jsonBody = JsonConvert.SerializeObject(body);
            await _httpClient.MakeApiRequest(RequestMethod.Put, $"/lol-chat/v2/friend-requests/{puuid}", jsonBody);
        }

        public Task<List<Invites>?> GetCurrentLobbyInvitesAsync()
        {
            throw new NotImplementedException();
        }

        public Task AcceptDuoInviteAsync(int inviteId)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Friends>?> GetCurrentFriendsListAsync()
        {
            var response = await _httpClient.MakeApiRequest(RequestMethod.Get, "/lol-chat/v1/friends");
            return JsonConvert.DeserializeObject<List<Friends>>(response);
        }

        public Task<List<Champions>?> GetCurrentChampionsAsync()
        {
            throw new NotImplementedException();
        }

        public Task InviteFriendASync(string summonerId)
        {
            throw new NotImplementedException();
        }

        public Task DodgeLobbyAsync()
        {
            throw new NotImplementedException();
        }

        public Task SelectSummonerSpellAsync(SummonerSpell firstSpell, SummonerSpell secondSpell)
        {
            throw new NotImplementedException();
        }
    }
}
