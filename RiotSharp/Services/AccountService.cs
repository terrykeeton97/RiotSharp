using Newtonsoft.Json;
using RiotSharp.Enums;
using RiotSharp.Interfaces;
using RiotSharp.Models;
using RiotSharp.Utilities;

namespace RiotSharp.Services
{
    public class AccountService(HttpClientFactory httpClientFactory) : IAcccountService
    {
        public async Task<CurrentSession?> GetAccountSessionAsync()
        {
            return await httpClientFactory.MakeApiRequest<CurrentSession?>(RequestMethod.Get, "/lol-login/v1/session");
        }

        public async Task<Summoner.Root?> GetSummonerAsync()
        {
            return await httpClientFactory.MakeApiRequest<Summoner.Root?>(RequestMethod.Get, "/lol-summoner/v1/current-summoner");
        }

        public async Task<string?> GetUsernameAsync()
        {
            var response = await httpClientFactory.MakeApiRequest<string?>(RequestMethod.Get, "/lol-login/v1/session");
            var json = JsonConvert.DeserializeObject<dynamic>(response);
            return json.username;
        }

        public async Task<string?> GetSummonerIdAsync()
        {
            var response = await httpClientFactory.MakeApiRequest<string?>(RequestMethod.Get, "/lol-login/v1/session");
            var json = JsonConvert.DeserializeObject<dynamic>(response);
            return json.summonerId;
        }

        public async Task<Rank.Root?> GetSummonerRankAsync(string summonerName)
        {
            return await httpClientFactory.MakeApiRequest<Rank.Root?>(RequestMethod.Get, "/lol-ranked/v1/current-ranked-stats");
        }

        public async Task<ProfilePicture?> GetAllProfilePictureIdsAsync()
        {
            using var client = new HttpClient();
            var response = await client.GetStringAsync("https://ddragon.leagueoflegends.com/cdn/14.24.1/data/en_US/profileicon.json");
            return JsonConvert.DeserializeObject<ProfilePicture?>(response);
        }

        public async Task<string?> GetRpCountAsync()
        {
            return await httpClientFactory.MakeApiRequest<string?>(RequestMethod.Get, "/lol-inventory/v1/wallet/RP");
        }

        public async Task<OwnedSkins.Root> GetOwnedSkinsAsync()
        {
            return await httpClientFactory.MakeApiRequest<OwnedSkins.Root>(RequestMethod.Get, "/lol-inventory/v2/inventory/CHAMPION_SKIN");
        }

        public async Task<PlayerLootMap.Root> GetPlayerLootMapAsync()
        {
            return await httpClientFactory.MakeApiRequest<PlayerLootMap.Root>(RequestMethod.Get, "/lol-loot/v1/player-loot-map");
        }

        public async Task<string?> ChangeRiotIdAsync(string newRiotId, string newTagId)
        {
            var body = new { gameName = newRiotId, tagLine = newTagId };
            return await httpClientFactory.MakeApiRequest<string?>(RequestMethod.Post, "https://127.0.0.1/lol-summoner/v1/save-alias", JsonConvert.SerializeObject(body));
        }
    }
}