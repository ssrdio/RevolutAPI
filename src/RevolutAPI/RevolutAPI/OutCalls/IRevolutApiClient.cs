using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Http;
using System.Threading.Tasks;
using RevolutAPI.Helpers;
using RevolutAPI.Models.Authorization;
using Microsoft.Extensions.Caching.Memory;

namespace RevolutAPI.OutCalls
{
    public interface IRevolutApiClient
    {
        Task<T> Get<T>(string url);
        Task<Result<T>> Post<T>(string url, object obj);
        Task<T> Put<T>(string url, object obj);
        Task<T> Delete<T>(string url);
        Task<bool> Delete(string url);
        Task<Result<T>> PostFormData<T>(string url, List<KeyValuePair<string, string>> data);
    }
}
