namespace RevolutAPI.Models.BusinessApi.Payment
{
    public class TransactionType
    {
        public static string ATM = "atm";
        public static string CARD_PAYMENT = "card_payment";
        public static string CARD_REFUND = "card_refund";
        public static string CARD_CHARGEBACK = "card_chargeback";
        public static string CARD_CREDIT = "card_credit";
        public static string EXCHANGE = "exchange";
        public static string TRANSFER = "transfer";
        public static string LOAN = "loan";
        public static string FEE = "fee";
        public static string REFUND = "refund";
        public static string TOPUP = "topup";
        public static string TOPUP_RETURN = "topup_return";
        public static string TAX = "tax";
        public static string TAX_REFUND = "tax_refund";
    }
}