using BKBConcept.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BKBConcept.Data
{
    public class BKBContext: IdentityDbContext<MyUser>
    {
        public BKBContext(DbContextOptions<BKBContext> options) : base(options) { }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderProduct> OrderProducts { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<SellerProfile> SellerProfiles { get; set; }
        public DbSet<Wallet> Wallets { get; set; }
        public DbSet <WalletTransaction> WalletTransactions { get; set; }
        public DbSet <Group> Groups { get; set; }
        public DbSet <UserGroup> UserGroups { get; set; }
        public DbSet <Delivery> Deliveries { get; set; }
        public DbSet<DeliveryAddress> DeliveryAddresses { get; set; }
        public DbSet<Address> Addresses { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<MyUser>()
                .HasOne(u => u.Wallet)
                .WithOne(w => w.User)
                .HasForeignKey<MyUser>(u => u.WalletId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<MyUser>()
                .HasOne(u => u.SellerProfile)
                .WithOne(sp => sp.User)
                .HasForeignKey<SellerProfile>(sp => sp.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<MyUser>()
                .HasMany(u => u.Orders)
                .WithOne(o => o.Client)
                .HasForeignKey(o => o.ClientId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<MyUser>()
                .HasMany(u => u.Groups)
                .WithOne(g => g.User)
                .HasForeignKey(g => g.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<MyUser>()
                .HasOne(u => u.Address)
                .WithOne(a => a.User)
                .HasForeignKey<Address>(a => a.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Order>()
                .HasOne(o => o.Seller)
                .WithMany(s => s.Orders)
                .HasForeignKey(o => o.SellerId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Order>()
                .HasMany(o => o.Products)
                .WithOne(p => p.Order)
                .HasForeignKey(p => p.OrderId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Order>()
                .HasOne(o => o.Group)
                .WithMany(g => g.Orders)
                .HasForeignKey(o => o.GroupId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Order>()
                .HasOne(o => o.Delivery)
                .WithMany(d => d.Orders)
                .HasForeignKey(o => o.DeliveryId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Delivery>()
                .HasOne(d => d.Address)
                .WithOne(a => a.Delivery)
                .HasForeignKey<Delivery>(d => d.DeliveryAddressId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Product>()
                .HasOne(p => p.Category)
                .WithMany(c => c.Products)
                .HasForeignKey(p => p.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Product>()
                .HasOne(p => p.Seller)
                .WithMany(s => s.Products)
                .HasForeignKey(p => p.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Product>()
                .HasOne(p => p.Seller)
                .WithMany(s => s.Products)
                .HasForeignKey(p => p.SellerId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<SellerProfile>()
                .HasOne(sp => sp.Wallet)
                .WithOne(w => w.Seller)
                .HasForeignKey<Wallet>(w => w.SellerId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<Wallet>()
                .HasMany(w => w.Transactions)
                .WithOne(t => t.Wallet)
                .HasForeignKey(t => t.WalletId)
                .OnDelete(DeleteBehavior.Restrict);


        }
    }
}
