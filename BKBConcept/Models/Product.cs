using System.ComponentModel;

namespace BKBConcept.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public int QuantityAvailable { get; set; }
        public List <OrderProduct> Orders { get; set; }
        public int SellerId { get; set; }
        public SellerProfile Seller { get; set; }
        public decimal Price { get; set; }
        public string? ProductImgURL {get;set;}  
        public DateOnly HarvestDate { get; set; }
    }
}