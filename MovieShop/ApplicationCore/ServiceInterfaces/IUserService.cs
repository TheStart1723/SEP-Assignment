using ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.ServiceInterfaces
{
    public interface IUserService
    {
        Task<List<PurchaseResponseModel>> GetUserPurchasedMovies(int id);
        Task<List<MovieCardResponseModel>> GetUserFavoritedMovies(int id);
        Task<List<ReviewRequestModel>> GetUserReviews(int id);
        Task<UserDetailsModel> GetUserDetails(int id);
        Task<bool> EditUserProfile(UserDetailsModel userDetailsModel);
        Task<bool> CheckUserFavorite(int id, int movieId);
        Task<int> UserPurchase(PurchaseRequestModel model);
        Task<int> UserFavorite(FavoriteRequestModel model);
        Task<bool> UserReview(ReviewRequestModel model);
        Task<bool> DeleteFavorite(int userId, int movieId);
        Task<bool> EditReview(ReviewRequestModel model);
    }
}
