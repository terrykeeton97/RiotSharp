using RiotSharp.Models;

namespace RiotSharp
{
    public interface IChampion
    {
        Task<List<Champions>>? GetOwnedChampionsAsync();
        Task<List<Champions>>? GetFreeToPlayChampionsAsync();
        Task<List<Champions>?> GetAllChampionsAsync();
    }
}
