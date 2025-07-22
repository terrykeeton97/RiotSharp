using RiotSharp.Models;

namespace RiotSharp
{
    public interface IRiot
    {
        Task<Settings.Root> GetSettingsAsync();
        Task<string?> QuitClient();
        Task<string?> RestartUx();
    }
}
