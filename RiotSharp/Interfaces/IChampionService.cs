using RiotSharp.Models;

namespace RiotSharp.Interfaces
{
    internal interface IChampionService
    {
        public Task<List<Champions>>? GetOwnedChampionsAsync();

        public Task<List<Champions>>? GetFreeToPlayChampionsAsync();

        public Task<List<Champions>>? GetAllChampionsAsync();
    }
}