using Newtonsoft.Json;
using RiotSharp.Enums;
using RiotSharp.Interfaces;
using RiotSharp.Models;
using RiotSharp.Utilities;

namespace RiotSharp.Services
{
    public class ChampionSelectService(HttpClientFactory httpClientFactory) : IChampionSelectService
    {
        public async Task<ChampionSelect?> GetChampionSelectAsync()
        {
            return await httpClientFactory.MakeApiRequest<ChampionSelect?>(RequestMethod.Get, "/lol-champ-select/v1/session");
        }

        public async Task<string?> GetLockedChampionIdAsync()
        {
            return await httpClientFactory.MakeApiRequest<string?>(RequestMethod.Get, "/lol-champ-select/v1/current-champion");
        }

        public async Task HoverChampionAsync(int actionId, int championId)
        {
            var body = new { championId };
            var jsonBody = JsonConvert.SerializeObject(body);
            await httpClientFactory.MakeApiRequest<string?>(RequestMethod.Patch, $"/lol-champ-select/v1/session/actions/{actionId}", jsonBody);
        }

        public async Task<CurrentRunePage.Root> GetCurrentRunePageAsync()
        {
            return await httpClientFactory.MakeApiRequest<CurrentRunePage.Root>(RequestMethod.Get, "/lol-perks/v1/currentpage");
        }

        public async Task SelectSummonerSpellAsync(SummonerSpell primarySpell, SummonerSpell secondSummonerSpell)
        {
            var body = new { spell1Id = (int)primarySpell, spell2Id = (int)secondSummonerSpell };
            var jsonBody = JsonConvert.SerializeObject(body);
            await httpClientFactory.MakeApiRequest<string>(RequestMethod.Patch, "/lol-champ-select/v1/session/my-selection", jsonBody);
        }
        
        public async Task DodgeAsync()
        {
            await httpClientFactory.MakeApiRequest<string>(RequestMethod.Post, "/lol-login/v1/session/invoke?destination=lcdsServiceProxy&method=call&args=[\"\",\"teambuilder-draft\",\"quitV2\",\"\"]");
        }

        public async Task LockChampionAsync(int actionId, int championId)
        {
            var body = new { completed = true, championId };
            var jsonBody = JsonConvert.SerializeObject(body);
            await httpClientFactory.MakeApiRequest<string>(RequestMethod.Patch, $"/lol-champ-select/v1/session/actions/{actionId}", jsonBody);
        }
    }
}
