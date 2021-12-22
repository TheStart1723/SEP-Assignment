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
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
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
    }
}
