namespace RevolutAPI.Models.BusinessApi.Payment
{
    public class TransferState
    {
        public static string PENDING = "pending";
        public static string COMPLETED = "completed";
        public static string DECLINED = "declined";
        public static string FAILED = "failed";
        public static string CANCELLED = "cancelled";
    }
}