using RiotSharp.Models;

namespace RiotSharp.Interfaces
{
    internal interface IRiotService
    {
        //https://github.com/KebsCS/KBotExt/blob/a65f90767288bd0c94fcfb655507926eb9ffe8fd/KBotExt/MiscTab.h#L327
        public Task<Settings.Root> GetSettingsAsync();

        public Task<string?> QuitClient();

        public Task<string?> RestartUx();
    }
}
