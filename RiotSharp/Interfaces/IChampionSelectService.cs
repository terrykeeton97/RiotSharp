using RiotSharp.Enums;
using RiotSharp.Models;

namespace RiotSharp.Interfaces
{
    internal interface IChampionSelectService
    {
        public Task<ChampionSelect?> GetChampionSelectAsync();

        public Task<string?> GetLockedChampionIdAsync();

        public Task HoverChampionAsync(int actionId, int championId);

        public Task SelectSummonerSpellAsync(SummonerSpell primarySpell, SummonerSpell seconSummonerSpell);

        public Task DodgeAsync();

        public Task LockChampionAsync(int actionId, int championId);

        //https://github.com/KebsCS/KBotExt/blob/a65f90767288bd0c94fcfb655507926eb9ffe8fd/KBotExt/GameTab.h#L1667
        public Task<CurrentRunePage.Root> GetCurrentRunePageAsync();
    }
}