namespace poc.trading.api.Entities.Dto
{
    public class Stocks
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public long AvailableQuantity { get; set; }
        public long TotalQuantity { get; set; }
    }
}
