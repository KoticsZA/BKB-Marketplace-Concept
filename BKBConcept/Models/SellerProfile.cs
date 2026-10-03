namespace BKBConcept.Models
{
    public class SellerProfile
    {
        public int Id { get; set; }
        public string BusinessName { get; set; } = string.Empty;
        public string Bio { get; set; } = string.Empty;
        public string? NationalIdURL { get; set; }
        public List<Product> Products { get; set; } = new List<Product>(); 
        public bool IsApproved { get; set; } = false;
        public int WalletId { get; set; }
        public Wallet Wallet { get; set; } = new Wallet();
        public List<Order> Orders { get; set; } = new List<Order>();
        public string UserId { get; set; }
        public MyUser User { get; set; }
    }
}