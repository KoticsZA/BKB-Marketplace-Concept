namespace BKBConcept.Models
{
    public class Delivery
    {
        public int Id { get; set; }
        public int DeliveryAddressId { get; set; }
        public DeliveryAddress Address { get; set; }
        public DeliveryType Type { get; set; } = DeliveryType.SellerDelivery;
        public DateOnly? DeliveryDate { get; set; } = DateOnly.FromDateTime(DateTime.UtcNow).AddDays(7);
        public List <Order> Orders { get; set; }
    }

    public enum DeliveryType
    {
        SellerDelivery, ClientCollection, Courier   
    }
}