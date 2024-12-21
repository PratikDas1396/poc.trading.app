namespace poc.trading.api.Entities.Dto
{
    public class CreateOrderRequest
    {
        public string Id { get; set; }
        public string StockId { get; set; }
        public string UserId { get; set; }
        public long Quantity { get; set; }
        public double Price { get; set; }
        public double TotalPrice { get { return Quantity * Price; } }
    }
}
