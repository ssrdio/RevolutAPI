using RevolutAPI.OutCalls.MerchantApi;
using RevolutAPI.OutCalls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RevolutAPI.Models.MerchantApi.Customers;
using Xunit;
using RevolutAPI.Models.MerchantApi.Locations;
using RevolutAPI.Models.MerchantApi.Locations.Objects;
using RevolutAPI.Helpers;

namespace RevolutAPI.Tests.MerchantApi
{
    public class LocationsApiTest
    {
        private LocationsApiClient _locationsApiClient;
        private static readonly string LOCATION_ID = "";

        public LocationsApiTest()
        {
            _locationsApiClient = new LocationsApiClient(new RevolutSimpleClient(Config.MERCHANTAPIKEY, Config.MERCHANTAPIVERSION, Config.MERCHANTENDPOINT));
        }

        [Fact]
        public async void CreateLocation()
        {
            CreateLocationReq req = new CreateLocationReq
            {
                Name = "Test",
                Type = "Online",
                Details = new LocationDetails
                {
                    Domain = "krneki.com"
                }
            };
            Result<CreateLocationResp> resp = await _locationsApiClient.CreateLocation(req);
            Assert.NotNull(resp);
        }
        [Fact]
        public async void GetLocations()
        {
      
            List<GetLocationResp> resp = await _locationsApiClient.GetLocations();
            Assert.NotNull(resp);
        }
        [Fact]
        public async void GetLocation()
        {

            GetLocationResp resp = await _locationsApiClient.GetLocation(LOCATION_ID);
            Assert.NotNull(resp);
        }
        [Fact]
        public async void UpdateLocation()
        {
            UpdateLocationReq req = new UpdateLocationReq
            {
                Name= "New updated name",
            };
            GetLocationResp resp = await _locationsApiClient.UpdateLocation(LOCATION_ID, req);
            Assert.NotNull(resp);
        }
        [Fact]
        public async void DeleteLocation()
        {
         
            bool deleteLocation = await _locationsApiClient.DeleteLocation(LOCATION_ID);
            Assert.True(deleteLocation);
        }
    }
}
