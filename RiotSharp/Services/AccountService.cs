using Newtonsoft.Json;
using RiotSharp.Constants;
using RiotSharp.Enums;
using RiotSharp.Models;
using RiotSharp.Utilities;

namespace RiotSharp.Services
{
    public class AccountService : IAccount
    {
        private readonly HttpClientFactory _httpClientFactory;

        public AccountService()
        {
            _httpClientFactory = HttpClientFactory.Instance;
        }

        public async Task<CurrentSession?> GetAccountSession()
        {
            return await _httpClientFactory.GetAsync<CurrentSession?>(ApiEndpoints.AccountSession);
        }

        public async Task<Summoner.Root?> GetSummoner()
        {
            return await _httpClientFactory.GetAsync<Summoner.Root?>(ApiEndpoints.CurrentSummoner);
        }

        public async Task<string?> GetUsername()
        {
            var session = await _httpClientFactory.GetAsync<CurrentSession>(ApiEndpoints.AccountSession);
            return session?.Username;
        }

        public async Task<string?> GetSummonerId()
        {
            var session = await _httpClientFactory.GetAsync<CurrentSession>(ApiEndpoints.AccountSession);
            return session?.SummonerId?.ToString();
        }

        public async Task<Rank.Root?> GetSummonerRank(string summonerName)
        {
            return await _httpClientFactory.GetAsync<Rank.Root?>(ApiEndpoints.CurrentRankedStats);
        }

        public async Task<ProfilePicture?> GetAllProfilePictureIds()
        {
            return await _httpClientFactory.GetAsync<ProfilePicture?>(ApiEndpoints.ProfileIconsData);
        }

        public async Task<string?> GetRpCount()
        {
            using var response = await _httpClientFactory.GetAsync(ApiEndpoints.RpWallet);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }

        public async Task<OwnedSkins.Root> GetOwnedSkins()
        {
            return await _httpClientFactory.GetAsync<OwnedSkins.Root>(ApiEndpoints.OwnedSkins);
        }

        public async Task<PlayerLootMap.Root> GetPlayerLootMap()
        {
            return await _httpClientFactory.GetAsync<PlayerLootMap.Root>(ApiEndpoints.PlayerLootMap);
        }

        public async Task<string?> ChangeRiotId(string newRiotId, string newTagId)
        {
            var body = new { gameName = newRiotId, tagLine = newTagId };
            using var response = await _httpClientFactory.PostAsync(ApiEndpoints.SaveAlias, body);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }
    }
}
