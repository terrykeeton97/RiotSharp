using Newtonsoft.Json;
using RiotSharp.Enums;
using RiotSharp.Interfaces;
using RiotSharp.Models;
using RiotSharp.Utilities;

namespace RiotSharp.Services
{
    public class ChampionService : IChampionService
    {
        private HttpClientFactory _httpClient;
        private IAcccountService _accountService;

        public async Task<List<Champions>>? GetOwnedChampions()
        {
            var allChampions = await GetAllChampionsAsync();
            return allChampions?.Where(champ => champ?.Ownership?.Owned ?? false).ToList();
        }

        public async Task<List<Champions>>? GetFreeToPlayChampions()
        {
            var allChampions = await GetAllChampionsAsync();
            return allChampions?.Where(champ => champ?.FreeToPlay ?? false).ToList();
        }

        public async Task<List<Champions>>? GetAllChampionsAsync()
        {
            var account = await _accountService.GetAccountSessionAsync();
            var response = await _httpClient.MakeApiRequest(RequestMethod.Get, $"/lol-champions/v1/inventories/{account.AccountId}/champions-minimal");
            return JsonConvert.DeserializeObject<List<Champions>>(response);
        }
    }
}