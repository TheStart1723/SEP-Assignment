using ApplicationCore.Entities;
using ApplicationCore.Models;
using ApplicationCore.RepositoryInterfaces;
using ApplicationCore.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IPurchaseRepository _purchaseRepository;
        private readonly IReviewRepository _reviewRepository;
        private readonly IFavoriteRepository _favoriteRepository;
        public UserService(IUserRepository userRepository, IPurchaseRepository purchaseRepository, IFavoriteRepository favoriteRepository, IReviewRepository reviewRepository)
        {
            _userRepository = userRepository;
            _purchaseRepository = purchaseRepository;
            _reviewRepository = reviewRepository;
            _favoriteRepository = favoriteRepository;
        }
        public async Task<bool> EditUserProfile(UserDetailsModel model)
        {
            var dbUser = await _userRepository.GetUserByEmail(model.Email);
            if (dbUser != null)
            {
                return false; // email already exists
            }
            var user = new User
            {
                Id = model.Id,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                DateOfBirth = model.DateOfBirth,
                PhoneNumber = model.PhoneNumber
            };
            await _userRepository.Update(user);
            return true;

        }

        public async Task<UserDetailsModel> GetUserDetails(int id)
        {
            var user = await _userRepository.GetById(id);
            var userDetails = new UserDetailsModel
            {
                Id = user.Id,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                DateOfBirth = user.DateOfBirth,
                PhoneNumber = user.PhoneNumber
            };

            return userDetails;
        }

        public async Task<List<MovieCardResponseModel>> GetUserFavoritedMovies(int id)
        {
            var user = await _userRepository.GetById(id);
            var favorites = new List<MovieCardResponseModel>();
            foreach (var favorite in user.Favorites)
            {
                favorites.Add(new MovieCardResponseModel
                {
                    Id = favorite.Id,
                    PosterUrl = favorite.Movie.PosterUrl,
                    Title = favorite.Movie.Title,
                });
            }
            return favorites;
        }

        public async Task<List<PurchaseResponseModel>> GetUserPurchasedMovies(int id)
        {
            var user = await _userRepository.GetById(id);
            var purchases = new List<PurchaseResponseModel>();
            foreach (var purchase in user.Purchases)
            {
                purchases.Add(new PurchaseResponseModel
                {
                    Id = purchase.Id,
                    PosterUrl = purchase.Movie.PosterUrl,
                    Title = purchase.Movie.Title,
                    PurchaseDateTime = purchase.PurchaseDateTime,
                    PurchaseNumber = purchase.PurchaseNumber,
                    TotalPrice = purchase.TotalPrice,
                });
            }
            return purchases;
        }
        public async Task<List<ReviewRequestModel>> GetUserReviews(int id)
        {
            var user = await _userRepository.GetById(id);
            var reviews = new List<ReviewRequestModel>();
            foreach (var review in user.ReviewsofUser)
            {
                reviews.Add(new ReviewRequestModel
                {
                    UserId = review.UserId,
                    MovieId = review.MovieId,
                    Rating = review.Rating,
                    ReviewText = review.ReviewText,
                });
            }
            return reviews;
        }
        public async Task<bool> CheckUserFavorite(int id, int movieId)
        {
            var user = await _userRepository.GetById(id);
            if(user == null) return false;
            foreach(var favorite in user.Favorites)
            {
                if (movieId == favorite.MovieId) return true;
            }
            return false;
        }
        public async Task<int> UserPurchase(PurchaseRequestModel model)
        {
            var dbPurchase = await _purchaseRepository.GetPurchaseByNumber(model.PurchaseNumber);
            if(dbPurchase != null) return -1;
            var purchase = new Purchase
            {
                PurchaseNumber = model.PurchaseNumber,
                MovieId = model.MovieId,
                UserId = model.UserId,
                PurchaseDateTime = model.PurchaseDateTime,
                TotalPrice = model.TotalPrice,
            };
            var createdPurchase = await _purchaseRepository.Add(purchase);
            return createdPurchase.Id;

        }
        public async Task<int> UserFavorite(FavoriteRequestModel model)
        {
            var dbFavorite = await _favoriteRepository.GetFavorite(model.UserId, model.MovieId);
            if (dbFavorite != null) return -1;
            var favorite = new Favorite
            {
                MovieId = model.MovieId,
                UserId = model.UserId
            };
            var createdFavorite = await _favoriteRepository.Add(favorite);
            return createdFavorite.Id;
        }
        public async Task<bool> UserReview(ReviewRequestModel model)
        {
            var dbReview = await _reviewRepository.GetReview(model.UserId, model.MovieId);
            if (dbReview != null) return false;
            var review = new Review
            {
                MovieId = model.MovieId,
                UserId = model.UserId,
                Rating = model.Rating,
                ReviewText = model.ReviewText,
            };
            await _reviewRepository.Add(review);
            return true;
        }
        public async Task<bool> DeleteFavorite(int userId, int movieId)
        {
            var dbFavorite = await _favoriteRepository.GetFavorite(userId, movieId);
            if (dbFavorite == null) return false;
            await _favoriteRepository.Delete(dbFavorite.Id);
            return true;
        }
        public async Task<bool> EditReview(ReviewRequestModel model)
        {
            var dbReview = await _reviewRepository.GetReview(model.UserId, model.MovieId);
            if (dbReview == null) return false;
            var review = new Review
            {
                UserId = model.UserId,
                MovieId = model.MovieId,
                ReviewText = model.ReviewText,
                Rating = model.Rating,
            };
            await _reviewRepository.Update(review);
            return true;
        }
    }
}
