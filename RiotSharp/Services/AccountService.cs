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

        public async Task<ProfilePicture?> GetAllProfilePictureIds()
        {
            using var client = new HttpClient();
            var response = await client.GetStringAsync("https://ddragon.leagueoflegends.com/cdn/14.24.1/data/en_US/profileicon.json");
            return JsonConvert.DeserializeObject<ProfilePicture?>(response);
        }
    }
}