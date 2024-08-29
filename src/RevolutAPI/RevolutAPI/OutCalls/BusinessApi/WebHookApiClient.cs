using RevolutAPI.Helpers;
using RevolutAPI.Models.BusinessApi.WebHook;
using System;
using System.Threading.Tasks;

namespace RevolutAPI.OutCalls.BusinessApi
{
    public class WebHookApiClient
    {
        private readonly IRevolutApiClient _apiClient;

        public WebHookApiClient(IRevolutApiClient apiClient)
        {
            _apiClient = apiClient;
        }

        public async Task<GetWebHookResp> GetWebHook()
        {
            string endpoint = "/webhook";
            return await _apiClient.Get<GetWebHookResp>(endpoint);
        }

        public async Task<Result<WebHookResp>> CreateWebHook(AddWebHookReq req)
        {
            Uri uriResult;
            bool resultUriHttps = Uri.TryCreate(req.Url, UriKind.Absolute, out uriResult)
                && uriResult.Scheme == Uri.UriSchemeHttps;

            if (!resultUriHttps)
            {
                return Result.Fail<WebHookResp>("Only HTTPS URLs are supported");
            }

            string endpoint = "/webhook";
            Result<WebHookResp> result = await _apiClient.Post<WebHookResp>(endpoint, req);
            return result;
        }

        public async Task<WebHookResp> DeleteWebHook()
        {
            string endpoint = "/webhook";
            return await _apiClient.Delete<WebHookResp>(endpoint);
        }
    }
}
