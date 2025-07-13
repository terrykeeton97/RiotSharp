using RiotSharp.Models;

namespace RiotSharp.Interfaces
{
    public interface IChampionService
    {
        public Task<List<Champions>>? GetOwnedChampionsAsync();

        public Task<List<Champions>>? GetFreeToPlayChampionsAsync();

        public Task<List<Champions>?> GetAllChampionsAsync();
    }
}
