using ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.ServiceInterfaces
{
    public interface IMovieService
    {
        Task<IEnumerable<MovieCardResponseModel>> GetHighestGrossingMovies();
        Task<MovieDetailsResponseModel> GetMovieDetailsById(int id);
        Task<IEnumerable<MovieCardResponseModel>> GetAllMovies();
        Task<IEnumerable<MovieCardResponseModel>> GetTopRatedMovies();
        Task<IEnumerable<MovieCardResponseModel>> GetMoviesByGenre(int genreId);
        Task<IEnumerable<ReviewRequestModel>> GetReviews(int id);
    }
}
