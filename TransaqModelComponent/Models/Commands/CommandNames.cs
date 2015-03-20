
namespace TransaqModelComponent.Models.Commands
{
    public static class CommandNames
    {
        public const string Name = "command";

        // Использовать модель Connection
        public const string Connection = "connect";
        public const string Disconnection = "disconnect";
        public const string Status = "server_status";

        // Использовать модель Subscribe
        public const string Subscribe = "subscribe";
        public const string Unsubscribe = "unsubscribe";

        public const string GetHistoryData = "get_history_data";

        public const string NewOrder = "neworder";
        public const string MoveOrder = "moveorder";
        public const string NewCondOrder = "newcondorder";
        public const string NewStopOrder = "newstoporder";
        public const string CancelOrder = "cancelorder";
        public const string CancelStopOrder = "cancelstoporder";

        public const string SubscribeTicks = "subscribe_ticks";

        public const string ChangePass = "change_pass";

        public const string GetFortsPosition = "get_forts_position";
        public const string GetClientLimits = "get_client_limits";

        public const string GetLeverageControl = "get_leverage_control";

        public const string GetSecurities = "get_securities";
        public const string GetSecuritiesInfo = "get_securities_info";

        public const string GetPortfolio = "get_portfolio";
        public const string GetPortfolioMct = "get_portfolio_mct";

        public const string GetMaxBuySellTPlus = "get_max_buy_sell_tplus";

        public const string GetMarkets = "get_markets";
        public const string GetConnectorVersion = "get_connector_version";
        public const string GetServtimeDifference = "get_servtime_difference";
    }
}
