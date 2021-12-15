﻿using ApplicationCore.Models;
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
        public Task<bool> EditUserProfile(UserDetailsResponseModel userDetails)
        {
            throw new NotImplementedException();
        }

        public Task<List<UserDetailsResponseModel>> GetUserDetails(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<MovieCardResponseModel>> GetUserFavoritedMovies(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<MovieCardResponseModel>> GetUserPurchasedMovies(int id)
        {
            throw new NotImplementedException();
        }
    }
}
