using Newtonsoft.Json;
using RiotSharp.Enums;
using RiotSharp.Interfaces;
using RiotSharp.Models;
using RiotSharp.Utilities;

namespace RiotSharp.Services
{
    public class AccountService : IAcccountService
    {
        private readonly HttpClientFactory _httpClient = new();

        public async Task<CurrentSession?> GetAccountSessionAsync()
        {
            var response = await _httpClient.MakeApiRequest(RequestMethod.Get, "/lol-login/v1/session");
            return JsonConvert.DeserializeObject<CurrentSession>(response);
        }

        public async Task<Summoner.Root?> GetSummonerAsync()
        {
            var response = await _httpClient.MakeApiRequest(RequestMethod.Get, "/lol-summoner/v1/current-summoner");
            return JsonConvert.DeserializeObject<Summoner.Root?>(response);
        }

        public async Task<string?> GetUsernameAsync()
        {
            var response = await _httpClient.MakeApiRequest(RequestMethod.Get, "/lol-login/v1/session");

            var json = JsonConvert.DeserializeObject<dynamic>(response);
            return json.username;
        }

        public async Task<string?> GetSummonerIdAsync()
        {
            var response = await _httpClient.MakeApiRequest(RequestMethod.Get, "/lol-login/v1/session");

            var json = JsonConvert.DeserializeObject<dynamic>(response);
            return json.summonerId;
        }

        public async Task<Rank.Root?> GetSummonerRankAsync(string summonerName)
        {
            var response = await _httpClient.MakeApiRequest(RequestMethod.Get, "/lol-ranked/v1/current-ranked-stats");
            return JsonConvert.DeserializeObject<Rank.Root?>(response);
        }

        public async Task<ProfilePicture?> GetAllProfilePictureIds()
        {
            using var client = new HttpClient();
            var response = await client.GetStringAsync("https://ddragon.leagueoflegends.com/cdn/14.24.1/data/en_US/profileicon.json");
            return JsonConvert.DeserializeObject<ProfilePicture?>(response);
        }
    }
}