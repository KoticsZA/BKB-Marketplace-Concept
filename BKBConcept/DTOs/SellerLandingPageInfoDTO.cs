using BKBConcept.Models;

namespace BKBConcept.DTOs
{
    public class SellerLandingPageInfoDTO
    {
        public string BusinessName { get; set; } = string.Empty;
        public string Bio { get; set; } = string.Empty;
        public List<Product> Products { get; set; }
        public bool IsApproved { get; set; } = false;
        public Wallet Wallet { get; set; } = new Wallet();
        public List<Order> RecentOrders { get; set; } = new List<Order>();
        public string? UserImgURL { get; set; }
        public MyUser User { get; set; } 

    }
}
