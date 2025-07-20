using RiotSharp.Constants;
using RiotSharp.Enums;
using RiotSharp.Models;
using RiotSharp.Utilities;

namespace RiotSharp.Services
{
    internal class RiotService(HttpClientFactory httpClientFactory) : IRiotService
    {
        public async Task<Settings.Root> GetSettingsAsync()
        {
            return await httpClientFactory.MakeApiRequest<Settings.Root>(RequestMethod.Get, ApiEndpoints.GameSettings);
        }

        public async Task<string?> QuitClient()
        {
            return await httpClientFactory.MakeApiRequest<string?>(RequestMethod.Post, ApiEndpoints.QuitClient);
        }

        public async Task<string?> RestartUx()
        {
            return await httpClientFactory.MakeApiRequest<string?>(RequestMethod.Post, ApiEndpoints.RestartUx);
        }
    }
}
