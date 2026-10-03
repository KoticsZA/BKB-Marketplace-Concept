using BKBConcept.Data;
using BKBConcept.DTOs;
using BKBConcept.Interfaces;
using BKBConcept.Models;
using BKBConcept.ViewModels.Seller;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BKBConcept.Controllers
{
    [Authorize]
    public class SellerController : Controller
    {
        private readonly BKBContext _context;
        private readonly UserManager<MyUser> _userManager;
        private readonly ISellerService _sellerService;

        public SellerController(BKBContext context, UserManager<MyUser> userManager, ISellerService sellerService)
        {
            _context = context;
            _userManager = userManager;
            _sellerService = sellerService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(User);

            if (user == null)
            {
                return Unauthorized();
            }

            var dto = await _sellerService.GetSellerIndexInfoAsync(user.Id);

            var model = new SellerIndexViewModel
            {
                Firstname = dto.User.Firstname,
                Lastname = dto.User.Lastname,
                UserImgURL = dto.User.ProfileImgUrl,
                BusinessName = dto.BusinessName,
                Bio = dto.Bio,
                Wallet = dto.Wallet,
                RecentOrders = dto.RecentOrders
            };

            return View(model);
        }
    }
}
