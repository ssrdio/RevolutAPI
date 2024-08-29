using System;
using System.ComponentModel.DataAnnotations;

namespace RevolutAPI.Models.BusinessApi.Payment
{
    /** TYPES **/
    //    "atm"
    //    "card_payment"
    //    "card_refund"
    //    "card_chargeback"
    //    "card_credit"
    //    "exchange"
    //    "transfer"
    //    "loan"
    //    "fee"
    //    "refund"
    //    "topup"
    //    "topup_return"
    //    "tax"
    //    "tax_refund"


    public class GetTransactionsReq
    {
        [Required]
        public DateTime From { get; set; }
        [Required]
        public DateTime To { get; set; }
        public string CounterParty { get; set; }
        public int Count { get; set; }
        [Required]
        public string Type { get; set; }
    }
}