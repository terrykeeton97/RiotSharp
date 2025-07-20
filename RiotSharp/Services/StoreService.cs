using RiotSharp.Constants;
using RiotSharp.Enums;
using RiotSharp.Models;
using RiotSharp.Utilities;

namespace RiotSharp.Services
{
    internal class StoreService(HttpClientFactory httpClientFactory) : IStoreService
    {
        public async Task<Store.Catalog> GetStoreCatalogAsync()
        {
            return await httpClientFactory.MakeApiRequest<Store.Catalog>(RequestMethod.Get, ApiEndpoints.StoreCatalog);
        }

        public async Task<string> GetStoreUrlAsync()
        {
            return await httpClientFactory.MakeApiRequest<string>(RequestMethod.Get, ApiEndpoints.StoreUrl);
        }

        public async Task<string> GetSingedWalletJwtAsync()
        {
            return await httpClientFactory.MakeApiRequest<string>(RequestMethod.Get, ApiEndpoints.WalletJwt);
        }

        public async Task<Store.BearerToken> GetStoreBearerTokenAsync()
        {
            return await httpClientFactory.MakeApiRequest<Store.BearerToken>(RequestMethod.Get, ApiEndpoints.StoreBearerToken);
        }
    }
}
