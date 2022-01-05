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
        public async Task<IEnumerable<Movie>> Get30HighestGrossingMovies()
        {
            var movies = await _dbContext.Movies.OrderByDescending(m => m.Revenue).Take(30).ToListAsync();
            return movies;
        }

        public async override Task<Movie> GetById(int id)
        {
            var movieDetails = await _dbContext.Movies.Include(m => m.CastsofMovie).ThenInclude(m => m.Cast)
                    .Include(m => m.GenresofMovie).ThenInclude(m => m.Genre)
                    .Include(m => m.Reviews).Include(m => m.Trailers).Include(m => m.Purchases)
                    .FirstOrDefaultAsync(m => m.Id == id);

            if (movieDetails == null) return null;
            var rating = await _dbContext.Reviews.Where(m => m.MovieId == id).DefaultIfEmpty()
                    .AverageAsync(r => r == null ? 0 : r.Rating);
            movieDetails.Rating = rating;
            return movieDetails;
        }

        public async Task<IEnumerable<int>> Get30HighestRatedMovies()
        {
            var query = await _dbContext.Reviews.GroupBy(r => r.MovieId)
                .Select(group => new { MovieId = group.Key, rating = group.Average(r => r == null ? 0 : r.Rating) })
                .OrderByDescending(r => r.rating)
                .Take(30)
                .ToListAsync();
            var movieIds = new List<int>();
            foreach (var movie in query)
            {
                movieIds.Add(movie.MovieId);
            }
            return movieIds;
        }
        public async Task<IEnumerable<Movie>> GetMoviesByGenreId(int genreId)
        {
            var genre = await _dbContext.Genres.Include(g => g.MoviesofGenre).ThenInclude(g => g.Movie).FirstOrDefaultAsync(g => g.Id == genreId);
            var movies = new List<Movie>();
            foreach (var movie in genre.MoviesofGenre)
            {
                movies.Add(movie.Movie);
            }
            return movies;
        }
    }
}
