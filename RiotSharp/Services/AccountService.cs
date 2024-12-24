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
    }
}