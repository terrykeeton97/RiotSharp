using Newtonsoft.Json;
using RiotSharp.Constants;
using RiotSharp.Enums;
using RiotSharp.Models;
using RiotSharp.Utilities;

namespace RiotSharp.Services
{
    internal class AccountService(HttpClientFactory httpClientFactory) : IAccountService
    {
        public async Task<CurrentSession?> GetAccountSessionAsync()
        {
            return await httpClientFactory.MakeApiRequest<CurrentSession?>(RequestMethod.Get, ApiEndpoints.AccountSession);
        }

        public async Task<Summoner.Root?> GetSummonerAsync()
        {
            return await httpClientFactory.MakeApiRequest<Summoner.Root?>(RequestMethod.Get, ApiEndpoints.CurrentSummoner);
        }

        public async Task<string?> GetUsernameAsync()
        {
            var response = await httpClientFactory.MakeApiRequest<string?>(RequestMethod.Get, ApiEndpoints.AccountSession);
            var json = JsonConvert.DeserializeObject<dynamic>(response);
            return json?.username;
        }

        public async Task<string?> GetSummonerIdAsync()
        {
            var response = await httpClientFactory.MakeApiRequest<string?>(RequestMethod.Get, ApiEndpoints.AccountSession);
            var json = JsonConvert.DeserializeObject<dynamic>(response);
            return json?.summonerId;
        }

        public async Task<Rank.Root?> GetSummonerRankAsync(string summonerName)
        {
            return await httpClientFactory.MakeApiRequest<Rank.Root?>(RequestMethod.Get, ApiEndpoints.CurrentRankedStats);
        }

        public async Task<ProfilePicture?> GetAllProfilePictureIdsAsync()
        {
            using var client = new HttpClient();
            var response = await client.GetStringAsync(ApiEndpoints.ProfileIconsData);
            return JsonConvert.DeserializeObject<ProfilePicture?>(response);
        }

        public async Task<string?> GetRpCountAsync()
        {
            return await httpClientFactory.MakeApiRequest<string?>(RequestMethod.Get, ApiEndpoints.RpWallet);
        }

        public async Task<OwnedSkins.Root> GetOwnedSkinsAsync()
        {
            return await httpClientFactory.MakeApiRequest<OwnedSkins.Root>(RequestMethod.Get, ApiEndpoints.OwnedSkins);
        }

        public async Task<PlayerLootMap.Root> GetPlayerLootMapAsync()
        {
            return await httpClientFactory.MakeApiRequest<PlayerLootMap.Root>(RequestMethod.Get, ApiEndpoints.PlayerLootMap);
        }

        public async Task<string?> ChangeRiotIdAsync(string newRiotId, string newTagId)
        {
            var body = new { gameName = newRiotId, tagLine = newTagId };
            var jsonBody = JsonConvert.SerializeObject(body);
            return await httpClientFactory.MakeApiRequest<string?>(RequestMethod.Post, ApiEndpoints.SaveAlias, jsonBody);
        }
    }
}
