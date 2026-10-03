using BKBConcept.Models;

namespace BKBConcept.ViewModels.Seller
{
    public class SellerIndexViewModel
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string? UserImgURL { get; set; }
        public string BusinessName { get; set; }
        public string Bio { get; set; }
        public List<Product> Products { get; set; }
        public bool IsApproved { get; set; }
        public Wallet Wallet { get; set; }
        public List<Order> RecentOrders { get; set; }
        public string BuyerName { get; set; }
    }
}
