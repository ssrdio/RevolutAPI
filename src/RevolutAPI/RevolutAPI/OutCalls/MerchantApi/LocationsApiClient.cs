using RevolutAPI.Helpers;
using RevolutAPI.Models.MerchantApi.Customers;
using RevolutAPI.Models.MerchantApi.Locations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevolutAPI.OutCalls.MerchantApi
{
    public class LocationsApiClient
    {
        private readonly RevolutSimpleClient _apiClient;
        public LocationsApiClient(RevolutSimpleClient apiClient)
        {
            _apiClient = apiClient;
        }

        public async Task<Result<CreateLocationResp>> CreateLocation(CreateLocationReq req)
        {
            string endpoint = "/api/locations";
            Result<CreateLocationResp> result = await _apiClient.Post<CreateLocationResp>(endpoint, req);
            return result;
        }
        public async Task<List<GetLocationResp>> GetLocations()
        {
            string endpoint = "/api/locations";
            List<GetLocationResp> result = await _apiClient.Get<List<GetLocationResp>>(endpoint);
            return result;
        }
        public async Task<GetLocationResp> GetLocation(string locationId)
        {
            string endpoint = $"/api/locations/{locationId}";
            GetLocationResp result = await _apiClient.Get<GetLocationResp>(endpoint);
            return result;
        }
        public async Task<GetLocationResp> UpdateLocation(string locationId,UpdateLocationReq req)
        {
            string endpoint = $"/api/locations/{locationId}";
            GetLocationResp result = await _apiClient.Patch<GetLocationResp>(endpoint,req);
            return result;
        }
        public async Task<bool> DeleteLocation(string locationId)
        {
            if (string.IsNullOrEmpty(locationId))
            {
                throw new ArgumentException();
            }

            string endpoint = $"/api/locations/{locationId}";
            bool result = await _apiClient.Delete(endpoint);
            return result;
        }
    }
}
