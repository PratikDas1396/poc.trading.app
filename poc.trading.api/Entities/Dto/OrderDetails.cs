namespace poc.trading.api.Entities.Dto
{
    public class OrderDetails
    {
        public string Id { get; set; }
        public string StockId { get; set; }
        public string StockName { get; set; }
        public decimal Price { get; set; }
        public decimal TotalPrice { get; set; }
        public long Quantity { get; set; }
    }
}
