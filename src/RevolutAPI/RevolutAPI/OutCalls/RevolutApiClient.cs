using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using NLog;
using RevolutAPI.Models.Payment;
using Newtonsoft.Json.Serialization;

using Newtonsoft.Json.Linq;
using RevolutAPI.Helpers;
using RevolutAPI.Models;

namespace RevolutAPI.OutCalls
{
    public class RevolutApiClient : IRevolutApiClient
    {
        private readonly ILogger _logger = LogManager.GetCurrentClassLogger();
        private HttpClient _httpClient;
        private string _endpoint;
        private JsonSerializerSettings _jsonSerializerSettings;

        public RevolutApiClient(string endpoint, string token) : this(new HttpClient(), endpoint, token)
        {
        }
        
        public RevolutApiClient(HttpClient httpClient, string endpoint, string token)
        {
            SetUp(endpoint, token, httpClient);
        }

        public RevolutApiClient()
        {
        }

        public void SetUp(string endpoint, string token, HttpClient httpClient = null)
        {
            if(httpClient == null)
            {
                _httpClient = new HttpClient();
            }
            else
            {
                _httpClient = httpClient;
            }

            _endpoint = endpoint;

            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);


            _jsonSerializerSettings = new JsonSerializerSettings
            {
                ContractResolver = new DefaultContractResolver
                {
                    NamingStrategy = new SnakeCaseNamingStrategy()
                },
                DateFormatString = "yyyy-MM-dd"
            };
        }

        public async Task<T> Get<T>(string url)
        {
            string responseContent = "";
            try
            {
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

        public async Task<T> Put<T>(string url, object obj)
        {
            string responseContent = "";
            try
            {
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
