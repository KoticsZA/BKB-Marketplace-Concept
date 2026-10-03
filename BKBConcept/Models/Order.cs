using System.Net.Mail;

namespace BKBConcept.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string? ClientId { get; set; }
        public MyUser? Client { get; set; }
        public int SellerId { get; set; }
        public SellerProfile Seller { get; set; }
        public List<OrderProduct> Products { get; set; } = new List<OrderProduct>();
        public decimal OrderCost { get; set; }
        public OrderStatus Status { get; set; } = OrderStatus.Recorded;
        public int? GroupId { get; set; }
        public Group? Group { get; set; }
        public int DeliveryId { get; set; }
        public Delivery Delivery { get; set; }
        public DateTime CreatedAt { get; set; }
    }
    public enum OrderStatus
    {
        Recorded, Confirmed, Dispatched, Completed
    }
}