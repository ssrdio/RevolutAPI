using System;
using System.Collections.Generic;
using System.Text;

namespace RevolutAPI.Models.MerchantApi.Webhook
{
    public enum WebhookTypeEnum
    {
        ORDER_COMPLETED, 
        ORDER_AUTHORISED, 
        ORDER_PAYMENT_AUTHENTICATED, 
        ORDER_PAYMENT_DECLINED, 
        ORDER_PAYMENT_FAILED
    }
}
