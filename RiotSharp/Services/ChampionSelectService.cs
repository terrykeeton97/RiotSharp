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
            var response = await httpClientFactory.MakeApiRequest(RequestMethod.Get, "lol-champ-select/v1/session");
            return JsonConvert.DeserializeObject<ChampionSelect?>(response);
        }

        public async Task HoverChampionAsync(int actionId, int championId)
        {
            await httpClientFactory.MakeApiRequest(RequestMethod.Patch, "/lol-champ-select/v1/session/actions/" + actionId, "{\"championId\":" + championId + "}");
        }

        public Task SelectSummonerSpellAsync(SummonerSpell primarySpell, SummonerSpell seconSummonerSpell)
        {
            throw new NotImplementedException();
        }

        public Task DodgeLobbyAsync()
        {
            throw new NotImplementedException();
        }
    }
}