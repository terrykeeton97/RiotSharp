using RiotSharp.Models;

namespace RiotSharp.Interfaces
{
    internal interface IStoreService
    {
        //https://github.com/KebsCS/KBotExt/blob/a65f90767288bd0c94fcfb655507926eb9ffe8fd/KBotExt/GameTab.h#L891
        public Task<Store.Catalog> GetStoreCatalogAsync();

        //https://github.com/KebsCS/KBotExt/blob/a65f90767288bd0c94fcfb655507926eb9ffe8fd/KBotExt/GameTab.h#L951
        public Task<string> GetStoreUrlAsync();

        //https://github.com/KebsCS/KBotExt/blob/a65f90767288bd0c94fcfb655507926eb9ffe8fd/KBotExt/GameTab.h#L959
        public Task<string> GetSingedWalletJwtAsync();

        //https://github.com/KebsCS/KBotExt/blob/a65f90767288bd0c94fcfb655507926eb9ffe8fd/KBotExt/GameTab.h#L979
        public Task<Store.BearerToken> GetStoreBearerTokenAsync();
    }
}