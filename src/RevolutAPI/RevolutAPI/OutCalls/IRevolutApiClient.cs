using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Http;
using System.Threading.Tasks;

namespace RevolutAPI.OutCalls
{
    public interface IRevolutApiClient
    {
        void SetUp(string endpoint, string token, HttpClient httpClient = null);
        Task<T> Get<T>(string url);
        Task<T> Post<T>(string url, object obj);
        Task<T> Put<T>(string url, object obj);
        Task<T> Delete<T>(string url);
        Task<bool> Delete(string url); 
    }
}
