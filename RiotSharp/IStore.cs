using RiotSharp.Models;

namespace RiotSharp
{
    public interface IStore
    {
        Task<Store.Catalog> GetStoreCatalogAsync();
        Task<string> GetStoreUrlAsync();
        Task<string> GetSingedWalletJwtAsync();
        Task<Store.BearerToken> GetStoreBearerTokenAsync();
    }
}
