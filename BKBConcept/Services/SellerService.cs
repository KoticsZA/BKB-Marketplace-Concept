using BKBConcept.Data;
using BKBConcept.DTOs;
using BKBConcept.Interfaces;
using BKBConcept.Models;
using BKBConcept.ViewModels.Seller;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace BKBConcept.Services
{
    public class SellerService:ISellerService
    {
        private readonly BKBContext _context;

        public SellerService(BKBContext context)
        {
            _context = context;
        }
        public async Task<SellerLandingPageInfoDTO> GetSellerIndexInfoAsync( string userId)
        {
            var user = await _context.Users.Include(u => u.SellerProfile)
                .ThenInclude(sp => sp.Wallet)
                .Include(u=>u.SellerProfile)
                .ThenInclude(sp => sp.Products)
                .Include(u=>u.SellerProfile)
                .ThenInclude(sp => sp.Orders)
                .FirstOrDefaultAsync(s => s.Id == userId);

            if (user == null)
            {
                throw new Exception("User not found");

            }

            Console.WriteLine($"user with the id {user.Id} has been found successfully");

            var seller = user.SellerProfile;

            var dto = new SellerLandingPageInfoDTO
            {
                BusinessName = seller.BusinessName,
                Bio = seller.Bio,
                Products = seller.Products,
                IsApproved = seller.IsApproved,
                Wallet = seller.Wallet,
                RecentOrders = user.Orders.ToList(),
                User = seller.User,
                UserImgURL = user.ProfileImgUrl
            };

            return dto;
        }
    }
}
