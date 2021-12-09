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
    public class MovieRepository: Repository<Movie>, IMovieRepository
    {
        public MovieRepository(MovieShopDbContext dbContext): base(dbContext)
        {
            
        }
        public IEnumerable<Movie> Get30HighestGrossingMovies()
        {
            var movies = _dbContext.Movies.OrderByDescending(m => m.Revenue).Take(30).ToList();
            return movies;
        }

        public override Movie GetById(int id)
        {
            var movieDetails = _dbContext.Movies.Include(m => m.CastsofMovie).ThenInclude(m => m.Cast)
                    .Include(m => m.GenresofMovie).ThenInclude(m => m.Genre).Include(m => m.Trailers)
                    .FirstOrDefault(m => m.Id == id);

            if (movieDetails == null) return null;
            var rating = _dbContext.Reviews.Where(m => m.MovieId == id).DefaultIfEmpty()
                    .Average(r => r == null ? 0 : r.Rating);
            movieDetails.Rating = rating;
            return movieDetails;
        }
    }
}
