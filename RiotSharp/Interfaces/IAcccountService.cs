using RiotSharp.Models;

namespace RiotSharp.Interfaces
{
    internal interface IAcccountService
    {
        public Task<CurrentSession?> GetAccountSessionAsync();

        public Task<string?> GetUsernameAsync();

        public Task<string?> GetSummonerIdAsync();
    }
}