using RiotSharp.Models;

namespace RiotSharp
{
    public interface IAccount
    {
        Task<CurrentSession?> GetAccountSession();
        Task<Summoner.Root?> GetSummoner();
        Task<string?> GetUsername();
        Task<string?> GetSummonerId();
        Task<Rank.Root?> GetSummonerRank(string summonerName);
        Task<ProfilePicture?> GetAllProfilePictureIds();
        Task<string?> GetRpCount();
        Task<OwnedSkins.Root> GetOwnedSkins();
        Task<PlayerLootMap.Root> GetPlayerLootMap();
        Task<string?> ChangeRiotId(string newRiotId, string newTagId);
    }
}
