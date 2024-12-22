using Newtonsoft.Json;
using RiotSharp.Enums;
using RiotSharp.Interfaces;
using RiotSharp.Models;
using RiotSharp.Utilities;

namespace RiotSharp.Services
{
    public class RiotApiClient : IRiotApiClient
    {
        private HttpClientFactory _httpClient = new();

        public async Task<CurrentSession> GetAccountSessionAsync()
        {
            var response = await _httpClient.MakeApiRequest(RequestMethod.Get, "/lol-login/v1/session");
            return JsonConvert.DeserializeObject<CurrentSession>(response)!;
        }

        public Task<Summoner?> GetSummonerAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Champions?> GetChampionAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Rank?> GetRankAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ChampionSelect?> GetChampionSelectAsync()
        {
            throw new NotImplementedException();
        }

        public async Task CreateSoloDuoLobbyAsync(QueueId queueId)
        {
            await _httpClient.MakeApiRequest(RequestMethod.Post, "/lol-lobby/v2/lobby", "{{\"queueId\":{queueId}}}");
        }

        public Task QueueAsync(QueueType queueType)
        {
            throw new NotImplementedException();
        }

        public Task HoverChampionAsync(int actionId, int championId)
        {
            throw new NotImplementedException();
        }

        public Task SelectRoleAsync(string firstRole, string secondRole)
        {
            throw new NotImplementedException();
        }

        public Task AcceptFriendRequestAsync(List<FriendRequest?> friendRequests)
        {
            throw new NotImplementedException();
        }

        public Task<List<Invites>?> GetCurrentLobbyInvitesAsync()
        {
            throw new NotImplementedException();
        }

        public Task AcceptDuoInviteAsync(int inviteId)
        {
            throw new NotImplementedException();
        }

        public Task<List<FriendRequest>?> CheckFriendRequestAsync()
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
