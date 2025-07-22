using RiotSharp.Constants;
using RiotSharp.Enums;
using RiotSharp.Models;
using RiotSharp.Utilities;

namespace RiotSharp.Services
{
    public class StoreService : IStore
    {
        private readonly HttpClientFactory _httpClientFactory;

        public StoreService()
        {
            _httpClientFactory = HttpClientFactory.Instance;
        }

        public async Task<Store.Catalog> GetStoreCatalogAsync()
        {
            return await _httpClientFactory.GetAsync<Store.Catalog>(ApiEndpoints.StoreCatalog);
        }

        public async Task<string> GetStoreUrlAsync()
        {
            return await _httpClientFactory.GetAsync<string>(ApiEndpoints.StoreUrl);
        }

        public async Task<string> GetSingedWalletJwtAsync()
        {
            return await _httpClientFactory.GetAsync<string>(ApiEndpoints.WalletJwt);
        }

        public async Task<Store.BearerToken> GetStoreBearerTokenAsync()
        {
            return await _httpClientFactory.GetAsync<Store.BearerToken>(ApiEndpoints.StoreBearerToken);
        }
    }
}
