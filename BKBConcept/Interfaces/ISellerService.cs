using BKBConcept.DTOs;
using BKBConcept.ViewModels.Seller;

namespace BKBConcept.Interfaces
{
    public interface ISellerService
    {
        Task<SellerLandingPageInfoDTO> GetSellerIndexInfoAsync( string sellerId);
    }
}
