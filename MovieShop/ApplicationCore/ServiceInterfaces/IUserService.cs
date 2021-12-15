﻿using ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.ServiceInterfaces
{
    public interface IUserService
    {
        Task<List<MovieCardResponseModel>> GetUserPurchasedMovies(int id);
        Task<List<MovieCardResponseModel>> GetUserFavoritedMovies(int id);
        Task<List<UserDetailsResponseModel>> GetUserDetails(int id);
        Task<bool> EditUserProfile(UserDetailsResponseModel userDetailsModel);
    }
}
