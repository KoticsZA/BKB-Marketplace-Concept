namespace BKBConcept.Models
{
    public class Address
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public MyUser User { get; set; }
        public string Street { get; set; }
        public string Suburb { get; set; }
        public string City { get; set; }
        public string Province { get; set; }
        public string ZipCode { get; set; }
    }
}