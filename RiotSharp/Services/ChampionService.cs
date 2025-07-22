using RiotSharp.Constants;
using RiotSharp.Enums;
using RiotSharp.Models;
using RiotSharp.Utilities;

namespace RiotSharp.Services
{
    public class ChampionService : IChampion
    {
        private readonly HttpClientFactory _httpClientFactory;

        public ChampionService()
        {
            _httpClientFactory = HttpClientFactory.Instance;
        }

        public async Task<List<Champions>?> GetOwnedChampionsAsync()
        {
            return await _httpClientFactory.GetAsync<List<Champions>?>(ApiEndpoints.OwnedChampions);
        }

        public async Task<List<Champions>?> GetFreeToPlayChampionsAsync()
        {
            var allChampions = await GetAllChampionsAsync();
            return allChampions?.Where(champ => champ?.FreeToPlay ?? false).ToList();
        }

        public async Task<List<Champions>?> GetAllChampionsAsync()
        {
            return await _httpClientFactory.GetAsync<List<Champions>?>(ApiEndpoints.AllChampions);
        }
    }
}
