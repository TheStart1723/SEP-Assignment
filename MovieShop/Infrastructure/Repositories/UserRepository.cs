using ApplicationCore.Entities;
using ApplicationCore.RepositoryInterfaces;
using Infrastructure.data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(MovieShopDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<User> GetUserByEmail(string email)
        {
            var user = await _dbContext.Users.FirstOrDefaultAsync(x => x.Email == email);
            return user;
        }

        public async override Task<User> GetById(int id)
        {
            var userDetails = await _dbContext.Users.Include(u => u.Favorites).ThenInclude(u => u.Movie)
                .Include(u => u.Purchases).ThenInclude(u => u.Movie)
                .Include(u => u.RolesofUser).ThenInclude(u => u.Role)
                .Include(u => u.ReviewsofUser).FirstOrDefaultAsync(u => u.Id == id);

            if(userDetails == null) return null;
            return userDetails;
        }
    }
}
