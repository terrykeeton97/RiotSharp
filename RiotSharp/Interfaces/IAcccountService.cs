using RiotSharp.Models;

namespace RiotSharp.Interfaces
{
    internal interface IAcccountService
    {
        public Task<CurrentSession?> GetAccountSessionAsync();

        public Task<Summoner.Root?> GetSummonerAsync();

        public Task<string?> GetUsernameAsync();

        public Task<string?> GetSummonerIdAsync();

        public Task<Rank.Root?> GetSummonerRankAsync(string summonerName);

        public Task<ProfilePicture?> GetAllProfilePictureIds();
    }
}