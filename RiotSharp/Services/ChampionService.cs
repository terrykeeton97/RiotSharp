using RiotSharp.Constants;
using RiotSharp.Enums;
using RiotSharp.Interfaces;
using RiotSharp.Models;
using RiotSharp.Utilities;

namespace RiotSharp.Services
{
    public class ChampionService(HttpClientFactory httpClientFactory) : IChampionService
    {
        public async Task<List<Champions>>? GetOwnedChampionsAsync()
        {
            return await httpClientFactory.MakeApiRequest<List<Champions>?>(RequestMethod.Get, ApiEndpoints.OwnedChampions);
        }

        public async Task<List<Champions>>? GetFreeToPlayChampionsAsync()
        {
            var allChampions = await GetAllChampionsAsync();
            return allChampions?.Where(champ => champ?.FreeToPlay ?? false).ToList();
        }

        public async Task<List<Champions>?> GetAllChampionsAsync()
        {
            return await httpClientFactory.MakeApiRequest<List<Champions>?>(RequestMethod.Get, ApiEndpoints.AllChampions);
        }
    }
}
