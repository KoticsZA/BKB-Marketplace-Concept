namespace BKBConcept.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string ClientId { get; set; }
        public MyUser Client { get; set; }
        public int SellerId { get; set; }
        public SellerProfile Seller { get; set; }
        public List<OrderProduct> Products { get; set; } = new List<OrderProduct>();
        public decimal OrderCost { get; set; }
        public OrderStatus Status { get; set; } = OrderStatus.Pending;
    }
    public enum OrderStatus
    {
        Pending, Confirmed, Dispatched, Completed
    }
}