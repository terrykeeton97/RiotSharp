using RiotSharp.Enums;
using RiotSharp.Models;

namespace RiotSharp.Interfaces
{
    internal interface IRiotApiClient
    {
        public Task<CurrentSession?> GetAccountSessionAsync();
        public Task<string?> GetUsernameAsync();
        public Task<List<Champions>>? GetAllChampionsAsync();
        public Task<Rank?> GetRankAsync();
        public Task<ChampionSelect?> GetChampionSelectAsync();
        public Task CreateLobby(QueueId queueId);
        public Task QueueAsync(QueueType queueType);
        public Task HoverChampionAsync(int actionId, int championId);
        public Task SelectRoleAsync(string firstRole, string secondRole);
        public Task AcceptFriendRequestAsync(List<FriendRequest?> friendRequests);
        public Task<List<Invites>?> GetCurrentLobbyInvitesAsync();
        public Task AcceptDuoInviteAsync(int inviteId);
        public Task<List<FriendRequest>?> CheckFriendRequestAsync();
        public Task<List<Friends>?> GetCurrentFriendsListAsync();
        public Task<List<Champions>?> GetCurrentChampionsAsync();
        public Task InviteFriendASync(string summonerId);
        public Task DodgeLobbyAsync();
        public Task SelectSummonerSpellAsync(SummonerSpell firstSpell, SummonerSpell secondSpell);
        public Task AcceptAllFriendRequestAsync(List<FriendRequest?> friendRequests);
    }
}
