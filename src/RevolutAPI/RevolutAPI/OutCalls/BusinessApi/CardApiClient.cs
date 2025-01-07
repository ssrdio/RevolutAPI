using RevolutAPI.Helpers;
using RevolutAPI.Models.BusinessApi.Card;
using RevolutAPI.Models.BusinessApi.Counterparties;
using RevolutAPI.Models.BusinessApi.PayoutLinks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevolutAPI.OutCalls.BusinessApi
{
    public class CardApiClient
    {
        private readonly IRevolutApiClient _apiClient;
        public CardApiClient(IRevolutApiClient client)
        {
            _apiClient = client;
        }

        public async Task<List<GetCardsResp>> GetCards(GetCardsReq request)
        {
            string endpoint = "/1.0/cards";

            var queryString = BuildQueryString(request);


            if (!string.IsNullOrEmpty(queryString))
            {
                endpoint += "?" + queryString;
            }
            return await _apiClient.Get<List<GetCardsResp>>(endpoint);
        }
        public async Task<Result<CreateCardResp>> CreateCard(CreateCardReq request)
        {
            string endpoint = "/1.0/cards";
            return await _apiClient.Post<CreateCardResp>(endpoint, request);
        }
        public async Task<GetCardsResp> GetCardDetails(string cardId)
        {
            string endpoint = $"/1.0/cards/{cardId}";
            return await _apiClient.Get<GetCardsResp>(endpoint);
        }
        public async Task<GetSensitiveCardDetailsResp> GetSensitiveCardDetails(string cardId)
        {
            string endpoint = $"/1.0/cards/{cardId}";
            return await _apiClient.Get<GetSensitiveCardDetailsResp>(endpoint);
        }
        public async Task<GetCardsResp> UpdateCardDetails(string cardId,UpdateCardReq req)
        {
            string endpoint = $"/1.0/cards/{cardId}";
            return await _apiClient.Patch<GetCardsResp>(endpoint,req);
        }
        public async Task<bool> TerminateCard(string cardId)
        {
            if (string.IsNullOrEmpty(cardId))
            {
                throw new ArgumentException();
            }
            string endpoint = $"/1.0/cards/{cardId}";
            bool result = await _apiClient.Delete(endpoint);
            return result;
        }
        public async Task<Result> FreezeCard(string cardId)
        {
            string endpoint = $"/1.0/cards/{cardId}/freeze";
            return await _apiClient.Post<Result>(endpoint, new { }); 
        }
        public async Task<Result> UnfreezeCard(string cardId)
        {
            string endpoint = $"/1.0/cards/{cardId}/freeze";
            return await _apiClient.Post<Result>(endpoint, new { }); 
        }

        private string BuildQueryString(GetCardsReq request)
        {
            var parameters = new List<string>();

            if (request.CreatedBefore.HasValue)
            {
                string createdBeforeDate = request.CreatedBefore.Value.ToString("yyyy-MM-dd");
                parameters.Add($"created_before={createdBeforeDate}");

            }

            if (request.Limit.HasValue)
            {
                parameters.Add($"limit={request.Limit.Value}");
            }

            return string.Join("&", parameters);
        }
    }
}
