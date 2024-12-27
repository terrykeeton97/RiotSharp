using Newtonsoft.Json;
using RiotSharp.Enums;
using RiotSharp.Interfaces;
using RiotSharp.Models;
using RiotSharp.Utilities;

namespace RiotSharp.Services
{
    public class ChampionService(HttpClientFactory httpClientFactory) : IChampionService
    {
        private IAcccountService _accountService;

        public async Task<List<Champions>>? GetOwnedChampionsAsync()
        {
            var allChampions = await GetAllChampionsAsync();
            return allChampions?.Where(champ => champ?.Ownership?.Owned ?? false).ToList();
        }

        public async Task<List<Champions>>? GetFreeToPlayChampionsAsync()
        {
            var allChampions = await GetAllChampionsAsync();
            return allChampions?.Where(champ => champ?.FreeToPlay ?? false).ToList();
        }

        public async Task<List<Champions>?> GetAllChampionsAsync()
        {
            var account = await _accountService.GetAccountSessionAsync();
            var response = await httpClientFactory.MakeApiRequest<List<Champions>?>(RequestMethod.Get, $"/lol-champions/v1/inventories/{account.AccountId}/champions-minimal");
            return JsonConvert.DeserializeObject<List<Champions>>(response.ToString());
        }
    }
}