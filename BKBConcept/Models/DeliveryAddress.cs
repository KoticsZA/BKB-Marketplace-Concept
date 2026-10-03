namespace BKBConcept.Models
{
    public class DeliveryAddress
    {
        public int Id { get; set; }
        public int DeliveryId { get; set; }
        public Delivery Delivery { get; set; }
        public int AddressId { get; set; }
        public Address Address { get; set; }
    }
}