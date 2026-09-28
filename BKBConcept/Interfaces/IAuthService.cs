using BKBConcept.ViewModels.Authentication;
using Microsoft.AspNetCore.Identity;

namespace BKBConcept.Interfaces
{
    public interface IAuthService
    {
        Task<IdentityResult> RegisterAsync(RegisterViewModel model);
        Task<SignInResult> LoginAsync(LoginViewModel model);
        Task<string?> UploadAsync(IFormFile? file, string folder);
    }
}
