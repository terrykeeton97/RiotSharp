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
            return await httpClientFactory.MakeApiRequest<ChampionSelect?>(RequestMethod.Get, "lol-champ-select/v1/session");
        }

        public async Task HoverChampionAsync(int actionId, int championId)
        {
            await httpClientFactory.MakeApiRequest<string?>(RequestMethod.Patch, "/lol-champ-select/v1/session/actions/" + actionId, "{\"championId\":" + championId + "}");
        }


        public Task SelectSummonerSpellAsync(SummonerSpell primarySpell, SummonerSpell seconSummonerSpell)
        {
            throw new NotImplementedException();
        }
        
        public async Task Dodge()
        {
            await httpClientFactory.MakeApiRequest<string>(RequestMethod.Post, "/lol-login/v1/session/invoke?destination=lcdsServiceProxy&method=call&args=[\"\",\"teambuilder-draft\",\"quitV2\",\"\"]", true);
        }

        public async Task LockChampion(int actionId, int championId)
        {
            await httpClientFactory.MakeApiRequest<string>(RequestMethod.Patch, "/lol-champ-select/v1/session/actions/" + actionId, "{\"completed\":true,\"championId\":" + championId + "}");
        }
    }
}