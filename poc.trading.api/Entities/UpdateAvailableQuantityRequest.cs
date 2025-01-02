namespace poc.trading.api.Entities
{
    public class UpdateAvailableQuantityRequest
    {
        public string StockId { get; set; }
        public long UpdatedQuantity { get; set; }
    }
}
