using RiotSharp.Models;

namespace RiotSharp.Interfaces
{
    internal interface IChampionService
    {
        public Task<List<Champions>>? GetOwnedChampions();

        public Task<List<Champions>>? GetFreeToPlayChampions();

        public Task<List<Champions>>? GetAllChampionsAsync();
    }
}