using Newtonsoft.Json;
using RiotSharp.Constants;
using RiotSharp.Enums;
using RiotSharp.Models;
using RiotSharp.Utilities;

namespace RiotSharp.Services
{
    public class ChampionSelectService : IChampionSelect
    {
        private readonly HttpClientFactory _httpClientFactory;

        public ChampionSelectService()
        {
            _httpClientFactory = HttpClientFactory.Instance;
        }

        public async Task<ChampionSelect?> GetChampionSelectAsync()
        {
            return await _httpClientFactory.GetAsync<ChampionSelect?>(ApiEndpoints.ChampionSelectSession);
        }

        public async Task<string?> GetLockedChampionIdAsync()
        {
            using var response = await _httpClientFactory.GetAsync(ApiEndpoints.CurrentChampion);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }

        public async Task HoverChampionAsync(int actionId, int championId)
        {
            var body = new { championId };
            using var response = await _httpClientFactory.PatchAsync(string.Format(ApiEndpoints.ChampionSelectAction, actionId), body);
            response.EnsureSuccessStatusCode();
        }

        public async Task<CurrentRunePage.Root> GetCurrentRunePageAsync()
        {
            return await _httpClientFactory.GetAsync<CurrentRunePage.Root>(ApiEndpoints.CurrentRunePage);
        }

        public async Task SelectSummonerSpellAsync(SummonerSpell primarySpell, SummonerSpell secondSummonerSpell)
        {
            var body = new { spell1Id = (int)primarySpell, spell2Id = (int)secondSummonerSpell };
            using var response = await _httpClientFactory.PatchAsync(ApiEndpoints.ChampionSelectMySelection, body);
            response.EnsureSuccessStatusCode();
        }
        
        public async Task DodgeAsync()
        {
            using var response = await _httpClientFactory.PostAsync(ApiEndpoints.DodgeGame);
            response.EnsureSuccessStatusCode();
        }

        public async Task LockChampionAsync(int actionId, int championId)
        {
            var body = new { completed = true, championId };
            using var response = await _httpClientFactory.PatchAsync(string.Format(ApiEndpoints.ChampionSelectAction, actionId), body);
            response.EnsureSuccessStatusCode();
        }
    }
}
