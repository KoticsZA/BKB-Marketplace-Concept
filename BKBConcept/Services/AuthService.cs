using BKBConcept.Data;
using BKBConcept.Interfaces;
using BKBConcept.Models;
using BKBConcept.ViewModels.Authentication;
using Microsoft.AspNetCore.Identity;

namespace BKBConcept.Services
{
    public class AuthService:IAuthService
    {
        private readonly UserManager<MyUser> _userManager;
        private readonly SignInManager<MyUser> _signInManager;
        private readonly IWebHostEnvironment _environment;
        private readonly BKBContext _context;

        public AuthService(UserManager<MyUser> userManager, SignInManager<MyUser> signInManager, IWebHostEnvironment environment, BKBContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _environment = environment;
            _context = context;
        }
        public async Task<IdentityResult> RegisterAsync(RegisterViewModel model)
        {
            var nationalIDURL = await UploadAsync(model.NationalId, "Documents");
            var seller = new SellerProfile
            {
                Bio = model.Bio,
                NationalIdURL = nationalIDURL
            };

            var profileImgURL = await UploadAsync(model.ProfileImage, "Images");
            var user = new MyUser
            {
                UserName = model.Firstname,
                Lastname = model.Lastname,
                ProfileImgUrl = profileImgURL,
                NormalizedUserName = model.Email,
                Email = model.Email,
                Role = model.Role,
                SellerProfile = seller
            };

            var result = await _userManager.CreateAsync(user);
            return result;
        }

        public async Task<string?> UploadAsync(IFormFile? file, string folder)
        {
            if (file == null || file.Length == 0)
                return null;

            var fileName = Guid.NewGuid() + Path.GetExtension(file.FileName);

            var uploadFolder = Path.Combine(
                _environment.WebRootPath,
                "uploads",
                folder
            );

            Directory.CreateDirectory(uploadFolder);

            var filePath = Path.Combine(uploadFolder, fileName);

            using var stream = new FileStream(filePath, FileMode.Create);
            await file.CopyToAsync(stream);

            return $"/uploads/{folder}/{fileName}";
        }

        public async Task<SignInResult> LoginAsync(LoginViewModel model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);
            var result = await _signInManager.PasswordSignInAsync(user, model.Password, model.RememberMe, false);

            return result;
        }
    }
}
