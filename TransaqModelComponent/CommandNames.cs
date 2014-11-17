
namespace TransaqModelComponent
{
    public static class CommandNames
    {
        public const string Name = "command";

        // Использовать модель Connection
        public const string Connection = "connect";
        public const string Disconnection = "disconnect";
        public const string Status = "server_status";
        public const string GetSecurities = "get_securities";

        // Использовать модель Subscribe
        public const string Subscribe = "subscribe";
        public const string Unsubscribe = "unsubscribe";

        public const string GetHistoryData = "get_history_data";
        public const string NewOrder = "neworder";
        public const string NewCondOrder = "newcondorder";
        public const string NewStopOrder = "newstoporder";
        public const string CancelOrder = "cancelorder";
        public const string CancelStopOrder = "cancelstoporder";

        public const string SubscribeTicks = "subscribe_ticks";
    }
}
