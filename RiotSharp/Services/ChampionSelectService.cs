using Newtonsoft.Json;
using RiotSharp.Constants;
using RiotSharp.Enums;
using RiotSharp.Models;
using RiotSharp.Utilities;

namespace RiotSharp.Services
{
    internal class ChampionSelectService(HttpClientFactory httpClientFactory) : IChampionSelectService
    {
        public async Task<ChampionSelect?> GetChampionSelectAsync()
        {
            return await httpClientFactory.MakeApiRequest<ChampionSelect?>(RequestMethod.Get, ApiEndpoints.ChampionSelectSession);
        }

        public async Task<string?> GetLockedChampionIdAsync()
        {
            return await httpClientFactory.MakeApiRequest<string?>(RequestMethod.Get, ApiEndpoints.CurrentChampion);
        }

        public async Task HoverChampionAsync(int actionId, int championId)
        {
            var body = new { championId };
            var jsonBody = JsonConvert.SerializeObject(body);
            await httpClientFactory.MakeApiRequest<string?>(RequestMethod.Patch, string.Format(ApiEndpoints.ChampionSelectAction, actionId), jsonBody);
        }

        public async Task<CurrentRunePage.Root> GetCurrentRunePageAsync()
        {
            return await httpClientFactory.MakeApiRequest<CurrentRunePage.Root>(RequestMethod.Get, ApiEndpoints.CurrentRunePage);
        }

        public async Task SelectSummonerSpellAsync(SummonerSpell primarySpell, SummonerSpell secondSummonerSpell)
        {
            var body = new { spell1Id = (int)primarySpell, spell2Id = (int)secondSummonerSpell };
            var jsonBody = JsonConvert.SerializeObject(body);
            await httpClientFactory.MakeApiRequest<string>(RequestMethod.Patch, ApiEndpoints.ChampionSelectMySelection, jsonBody);
        }
        
        public async Task DodgeAsync()
        {
            await httpClientFactory.MakeApiRequest<string>(RequestMethod.Post, ApiEndpoints.DodgeGame);
        }

        public async Task LockChampionAsync(int actionId, int championId)
        {
            var body = new { completed = true, championId };
            var jsonBody = JsonConvert.SerializeObject(body);
            await httpClientFactory.MakeApiRequest<string>(RequestMethod.Patch, string.Format(ApiEndpoints.ChampionSelectAction, actionId), jsonBody);
        }
    }
}
