namespace poc.trading.api.Entities
{
    public class UpdateStockRequest
    {
        public string StockId { get; set; }
        public decimal Price { get; set; }
        public long TotalQuantity { get; set; }
    }
}
