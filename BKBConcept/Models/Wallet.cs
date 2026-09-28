namespace BKBConcept.Models
{
    public class Wallet
    {
        public int Id { get; set; }
        public string? UserId { get; set; }
        public MyUser? User { get; set; }
        public int? SellerId { get; set; }
        public SellerProfile? Seller { get; set; }
        public decimal Balance { get; set; }
        public List<WalletTransaction> Transactions { get; set; } = new List<WalletTransaction>();
    }
}