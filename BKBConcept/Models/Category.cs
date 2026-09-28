namespace BKBConcept.Models
{
    public class Category
    {
        public int Id { get; set; }
        public List<Product> Products { get; set; } = new List<Product>();
        public string Name { get; set; } = string.Empty;
    }
}