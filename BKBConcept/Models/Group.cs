namespace BKBConcept.Models
{
    public class Group
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public List<UserGroup> Members { get; set; } = new List<UserGroup>();
        public int WalletId { get; set; }
        public Wallet Wallet { get; set; }
        public List<Order> Orders { get; set; }
    }
}
