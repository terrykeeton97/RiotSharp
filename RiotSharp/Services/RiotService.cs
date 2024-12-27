using RiotSharp.Enums;
using RiotSharp.Interfaces;
using RiotSharp.Models;
using RiotSharp.Utilities;

namespace RiotSharp.Services
{
    internal class RiotService(HttpClientFactory httpClientFactory) : IRiotService
    {
        public async Task<Settings.Root> GetSettingsAsync()
        {
            return await httpClientFactory.MakeApiRequest<Settings.Root>(RequestMethod.Get, "/lol-game-settings/v1/game-settings");
        }

        public async Task<string?> QuitClient()
        {
            return await httpClientFactory.MakeApiRequest<string?>(RequestMethod.Post, "/process-control/v1/process/quit");
        }

        public async Task<string?> RestartUx()
        {
            return await httpClientFactory.MakeApiRequest<string?>(RequestMethod.Post, "/riotclient/kill-and-restart-ux");
        }
    }
}
