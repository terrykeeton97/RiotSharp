using RiotSharp.Enums;
using RiotSharp.Interfaces;
using RiotSharp.Models;
using RiotSharp.Utilities;

namespace RiotSharp.Services
{
    public class StoreService(HttpClientFactory httpClientFactory) : IStoreService
    {
        public async Task<Store.Catalog> GetStoreCatalogAsync()
        {
            return await httpClientFactory.MakeApiRequest<Store.Catalog>(RequestMethod.Get, "/lol-store/v1/catalog");
        }

        public async Task<string> GetStoreUrlAsync()
        {
            return await httpClientFactory.MakeApiRequest<string>(RequestMethod.Get, "/lol-store/v1/getStoreUrl");
        }

        public async Task<string> GetSingedWalletJwtAsync()
        {
            return await httpClientFactory.MakeApiRequest<string>(RequestMethod.Get, "/lol-inventory/v1/signedWallet/RP");
        }

        public async Task<Store.BearerToken> GetStoreBearerTokenAsync()
        {
            return await httpClientFactory.MakeApiRequest<Store.BearerToken>(RequestMethod.Get, "/lol-rso-auth/v1/authorization/access-token");
        }
    }
}