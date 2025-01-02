namespace poc.trading.api.Entities
{
    public class DbConstants
    {
        public const string GET_ALL_STOCKS = "prc_getAllStocks";
        public const string GET_STOCKS = "prc_getStocks";
        public const string UPDATE_AVAILABLE_STOCK_QUANTITY = "prc_updateStockQuantity";
        public const string UPDATE_STOCK = "prc_updateStock";
        public const string ADD_WATCHLIST = "prc_addWatchlist"; 
        public const string GET_WATCHLIST = "prc_getWatchlist";
        public const string DELETE_WATCHLIST = "prc_deleteWatchlist";
        public const string CREATE_ORDER = "prc_createOrder";
        public const string GET_ORDER_DETAILS = "prc_GetOrderDetails";
        public const string GET_ORDER_BY_USER = "prc_GetUserOrderDetails";
        public const string GET_USER_DETAILS = "prc_getUserDetails";
        public const string GET_USER_DETAILS_BY_EMAIL = "prc_getUserDetailsByEmail";
    }
}
