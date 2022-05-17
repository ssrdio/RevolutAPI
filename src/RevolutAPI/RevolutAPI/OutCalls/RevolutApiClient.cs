using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using NLog;
using Newtonsoft.Json.Serialization;
using RevolutAPI.Helpers;
using RevolutAPI.Models;
using Microsoft.Extensions.Caching.Memory;
using RevolutAPI.Models.Authorization;

namespace RevolutAPI.OutCalls
{
    public class RevolutApiClient : IRevolutApiClient
    {
        private readonly ILogger _logger = LogManager.GetCurrentClassLogger();
        private HttpClient _httpClient;
        private string _endpoint;
        private JsonSerializerSettings _jsonSerializerSettings;
        private IMemoryCache _memoryCache;
        private readonly string ACCESS_TOKEN_KEY = "access_token_key";
        private RefreshAccessTokenModel _refreshAccessTokenModel;

        public RevolutApiClient(string endpoint)
        {
            _endpoint = endpoint;
            _httpClient = new HttpClient();
            _jsonSerializerSettings = new JsonSerializerSettings
            {
                ContractResolver = new DefaultContractResolver
                {
                    NamingStrategy = new SnakeCaseNamingStrategy()
                },
                DateFormatString = "yyyy-MM-dd"
            };
        }

        public RevolutApiClient(string endpoint, RefreshAccessTokenModel refreshAccessTokenModel, IMemoryCache memoryCache, HttpClient httpClient = null)
        {
            _memoryCache = memoryCache;

            _refreshAccessTokenModel = refreshAccessTokenModel;

            if(httpClient == null)
            {
                _httpClient = new HttpClient();
            }
            else
            {
                _httpClient = httpClient;
            }

            _endpoint = endpoint;

            _jsonSerializerSettings = new JsonSerializerSettings
            {
                ContractResolver = new DefaultContractResolver
                {
                    NamingStrategy = new SnakeCaseNamingStrategy()
                },
                DateFormatString = "yyyy-MM-dd"
            };
        }

        private async Task<string> GetAccessToken()
        {
            string accessKey;
            if (_memoryCache.TryGetValue(ACCESS_TOKEN_KEY, out accessKey))
            {
                return accessKey;
            }

            AuthorizationApiClient authorizationApiClient = new AuthorizationApiClient(this);
            Result<RefreshAccessTokenResp> refreshAccessTokenResp = await authorizationApiClient.RefreshAccessToken(
                _refreshAccessTokenModel.PrivateCert, 
                _refreshAccessTokenModel.CertificatePassword,
                _refreshAccessTokenModel.Issuer, 
                _refreshAccessTokenModel.ClientId, 
                _refreshAccessTokenModel.RefreshToken);
            if (refreshAccessTokenResp.Success)
            {
                _memoryCache.Set(ACCESS_TOKEN_KEY, 
                    refreshAccessTokenResp.Value.AccessToken, 
                    TimeSpan.FromSeconds(refreshAccessTokenResp.Value.ExpiresIn - 10));
                return refreshAccessTokenResp.Value.AccessToken;
            }
            throw new Exception("cannot_validate_token");
        }

        public async Task<T> Get<T>(string url)
        {
            string responseContent = "";
            try
            {
                string token = await GetAccessToken();
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer",token);
                var response = await _httpClient.GetAsync(_endpoint + url);
                if (response.Content != null)
                {
                    responseContent = await response.Content.ReadAsStringAsync();    
                }
                if (response.IsSuccessStatusCode)
                {
                    _logger.Info(responseContent);


                    return JsonConvert.DeserializeObject<T>(responseContent, _jsonSerializerSettings);
                }
                else
                {
                    _logger.Error(response.StatusCode + "Error: " + responseContent);
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex, responseContent);
            }
            return default(T);
        }
        
        public async Task<Result<T>> Post<T>(string url, object obj)
        {
            string responseContent = "";
            try
            {
                string token = await GetAccessToken();
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer",token);
                string postData = JsonConvert.SerializeObject(obj, _jsonSerializerSettings);
                var response = await _httpClient.PostAsync(_endpoint + url, new StringContent(postData, Encoding.UTF8, "application/json"));
                if (response.Content != null)
                {
                    responseContent = await response.Content.ReadAsStringAsync();
                }
                if (response.IsSuccessStatusCode)
                {
                    return Result.Ok(JsonConvert.DeserializeObject<T>(responseContent, _jsonSerializerSettings));
                }
                else if (!string.IsNullOrEmpty(responseContent))
                {
                    return Result.Fail<T>(JsonConvert.DeserializeObject<ErrorModel>(responseContent, _jsonSerializerSettings).Message);
                }
                else
                {
                    _logger.Error( $"Error posting data. Status code: {response.StatusCode}, Response: null");
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
            }
            return Result.Fail<T>();
        }


        public async Task<Result<T>> PostFormData<T>(string url, List<KeyValuePair<string, string>> data)
        {
            string responseContent = "";
            try
            {
                _httpClient = new HttpClient();
                FormUrlEncodedContent formContent = new FormUrlEncodedContent(data.ToArray());
                var response = await _httpClient.PostAsync(_endpoint + url, formContent);

                if (response.Content != null)
                {
                    responseContent = await response.Content.ReadAsStringAsync();
                }
                if (response.IsSuccessStatusCode)
                {
                    return Result.Ok(JsonConvert.DeserializeObject<T>(responseContent, _jsonSerializerSettings));
                }
                else if (!string.IsNullOrEmpty(responseContent))
                {
                    return Result.Fail<T>(JsonConvert.DeserializeObject<ErrorModel>(responseContent, _jsonSerializerSettings).Message);
                }
                else
                {
                    _logger.Error($"Error posting data. Status code: {response.StatusCode}, Response: null");
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
            }
            return Result.Fail<T>();
        }

        public async Task<T> Put<T>(string url, object obj)
        {
            string responseContent = "";
            try
            {
                string token = await GetAccessToken();
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                string postData = JsonConvert.SerializeObject(obj);
                var response = await _httpClient.PutAsync(_endpoint + url, new StringContent(postData, Encoding.UTF8, "application/json"));
                if (response.Content != null)
                {
                    responseContent = await response.Content.ReadAsStringAsync();    
                }
                if (response.IsSuccessStatusCode)
                {
                    return JsonConvert.DeserializeObject<T>(responseContent, _jsonSerializerSettings);
                }
                else
                {
                    _logger.Error(response.StatusCode + "Error: " + responseContent);
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
            }
            return default(T);
        }
        
        public async Task<T> Delete<T>(string url)
        {
            string responseContent = "";
            try
            {
                string token = await GetAccessToken();
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                var response = await _httpClient.DeleteAsync(_endpoint + url);
                responseContent = await response.Content.ReadAsStringAsync();
                if (response.IsSuccessStatusCode)
                {
                    return JsonConvert.DeserializeObject<T>(responseContent, _jsonSerializerSettings);
                }
                else
                {
                    _logger.Error(response.StatusCode + "Error: " + responseContent);
                }
            }
            catch (Exception ex)
            {
                
                _logger.Error(ex);
            }
            return default(T);
        }
        public async Task<bool> Delete(string url)
        {
            string responseContent = "";
            try
            {
                string token = await GetAccessToken();
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                var response = await _httpClient.DeleteAsync(_endpoint + url);
                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                else
                {
                    responseContent = await response.Content.ReadAsStringAsync();
                    _logger.Error(response.StatusCode + "Error: " + responseContent);
                    return false;
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
            }
            return false;
        }
    }
}
