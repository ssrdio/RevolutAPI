using RevolutAPI.Helpers;
using RevolutAPI.Models.BusinessApi.PaymentDrafts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevolutAPI.OutCalls.BusinessApi
{
    public class PaymentDraftsApiClient
    {
        private readonly IRevolutApiClient _revolutApiClient;

        public PaymentDraftsApiClient(IRevolutApiClient client)
        {
            _revolutApiClient = client;
        }

        public async Task<GetPaymentDraftsResp> GetPaymentDrafts()
        {
            string endpoint = "/1.0/payment-drafts";
            return await _revolutApiClient.Get<GetPaymentDraftsResp>(endpoint);
        }

        public async Task<GetPaymentDraftResp> GetPaymentDraft(string paymentDraftId)
        {
            string endpoint = $"/1.0/payment-drafts/{paymentDraftId}";
            return await _revolutApiClient.Get<GetPaymentDraftResp>(endpoint);
        }

        public async Task<Result<CreatePaymentDraftResp>> CreatePaymentDraft(CreatePaymentDraftReq request)
        {
            string endpoint = "/1.0/payment-drafts";
            return await _revolutApiClient.Post<CreatePaymentDraftResp>(endpoint,request);
        }

        public async Task<bool> DeletePaymentDraft(string paymentDraftId)
        {
            if (string.IsNullOrEmpty(paymentDraftId))
            {
                throw new ArgumentException();
            }

            string endpoint = $"/1.0/payment-drafts/{paymentDraftId}";
            return await _revolutApiClient.Delete(endpoint);
        }

    }
}
