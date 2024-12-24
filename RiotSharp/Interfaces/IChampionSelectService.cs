using RiotSharp.Enums;
using RiotSharp.Models;

namespace RiotSharp.Interfaces
{
    internal interface IChampionSelectService
    {
        public Task<ChampionSelect?> GetChampionSelectAsync();

        public Task HoverChampionAsync(int actionId, int championId);

        public Task SelectSummonerSpellAsync(SummonerSpell primarySpell, SummonerSpell seconSummonerSpell);

        public Task DodgeLobbyAsync();
    }
}