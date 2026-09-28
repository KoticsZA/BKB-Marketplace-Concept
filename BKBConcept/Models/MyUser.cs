using Microsoft.AspNetCore.Identity;

namespace BKBConcept.Models
{
    public class MyUser:IdentityUser
    {
        public string Firstname { get; set; } = string.Empty;
        public string Lastname { get; set; } = string.Empty;
        public string? ProfileImgUrl { get; set; }
        public string Role { get; set; } = "Client";
        public int WalletId { get; set; }
        public Wallet Wallet { get; set; } = new Wallet();
        public List<Order> Orders { get; set; } = new List<Order>();
        public int? SellerProfileId { get; set; }
        public SellerProfile? SellerProfile { get; set; }
    }
}
