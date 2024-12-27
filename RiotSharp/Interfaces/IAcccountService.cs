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

        public Task<ProfilePicture?> GetAllProfilePictureIdsAsync();

        public Task<string> GetRpCountAsync();

        public Task<OwnedSkins.Root> GetOwnedSkinsAsync();

        //https://github.com/KebsCS/KBotExt/blob/a65f90767288bd0c94fcfb655507926eb9ffe8fd/KBotExt/MiscTab.h#L350C65-L350C93
        public Task<PlayerLootMap.Root> GetPlayerLootMapAsync();

        //https://github.com/KebsCS/KBotExt/blob/a65f90767288bd0c94fcfb655507926eb9ffe8fd/KBotExt/MiscTab.h#L502
        public Task<string?> ChangeRiotIdAsync(string newRiotId, string newTagId);
    }
}