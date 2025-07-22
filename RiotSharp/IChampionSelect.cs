using RiotSharp.Enums;
using RiotSharp.Models;

namespace RiotSharp
{
    public interface IChampionSelect
    {
        Task<ChampionSelect?> GetChampionSelectAsync();
        Task<string?> GetLockedChampionIdAsync();
        Task HoverChampionAsync(int actionId, int championId);
        Task<CurrentRunePage.Root> GetCurrentRunePageAsync();
        Task SelectSummonerSpellAsync(SummonerSpell primarySpell, SummonerSpell secondSummonerSpell);
        Task DodgeAsync();
        Task LockChampionAsync(int actionId, int championId);
    }
}
