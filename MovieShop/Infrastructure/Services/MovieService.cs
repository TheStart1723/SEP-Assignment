using ApplicationCore.Models;
using ApplicationCore.RepositoryInterfaces;
using ApplicationCore.ServiceInterfaces;
using Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _movieRepository;
        public MovieService(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }
        public async Task<IEnumerable<MovieCardResponseModel>> GetHighestGrossingMovies()
        {
            // call my MovieRepository and get the data
            var movies = await _movieRepository.Get30HighestGrossingMovies();
            // 3rd party Automapper from Nuget
            var movieCards = new List<MovieCardResponseModel>();
            foreach (var movie in movies)
            {
                movieCards.Add(
                    new MovieCardResponseModel { Id = movie.Id, PosterUrl = movie.PosterUrl, Title = movie.Title }
                    );
            }

            return movieCards;
        }

        public async Task<MovieDetailsResponseModel> GetMovieDetailsById(int id)
        {
            var movie = await _movieRepository.GetById(id);
            var movieDetails = new MovieDetailsResponseModel
            {
                Id = movie.Id,
                PosterUrl = movie.PosterUrl,
                Title = movie.Title,
                OriginalLanguage = movie.OriginalLanguage,
                Overview = movie.Overview,
                Budget = movie.Budget,
                Revenue = movie.Revenue,
                ReleaseDate = movie.ReleaseDate,
                Rating = movie.Rating,
                Tagline = movie.Tagline,
                RunTime = movie.RunTime,
                BackdropUrl = movie.BackdropUrl,
                TmdbUrl = movie.TmdbUrl,
                ImdbUrl = movie.ImdbUrl,
                Price = movie.Price
            };
            foreach (var movieCast in movie.CastsofMovie)
            {
                movieDetails.Casts.Add(new CastResponseModel
                {

                    Id = movieCast.CastId,
                    Character = movieCast.Character,
                    Name = movieCast.Cast.Name,
                    PosterUrl = movieCast.Cast.ProfilePath
                });
            }

            foreach (var trailer in movie.Trailers)
            {
                movieDetails.Trailers.Add(new TrailerReponseModel
                {
                    Id = trailer.Id,
                    MovieId = trailer.Id,
                    Name = trailer.Name,
                    TrailerUrl = trailer.TrailerUrl
                });
            }

            foreach (var movieGenres in movie.GenresofMovie)
            {
                movieDetails.Genres.Add(new GenreModel { Id = movieGenres.GenreId, Name = movieGenres.Genre.Name });
            }

            foreach (var purchase in movie.Purchases)
            {
                movieDetails.Purchases.Add(new PurchaseMovieModel { Id = purchase.Id, MovieId = purchase.MovieId, UserId = purchase.UserId });
            }

            return movieDetails;
        }

        public async Task<IEnumerable<MovieCardResponseModel>> GetAllMovies()
        {
            var movies = await _movieRepository.GetAll();
            var movieCards = new List<MovieCardResponseModel>();
            foreach (var movie in movies)
            {
                movieCards.Add(new MovieCardResponseModel { Id = movie.Id, PosterUrl = movie.PosterUrl, Title = movie.Title });
            }
            return movieCards;
        }

        public async Task<IEnumerable<MovieCardResponseModel>> GetTopRatedMovies()
        {
            var movieIds = await _movieRepository.Get30HighestRatedMovies();
            var movieCards = new List<MovieCardResponseModel>();
            foreach (var id in movieIds)
            {
                var movie = await _movieRepository.GetById(id);
                movieCards.Add(new MovieCardResponseModel { Id = movie.Id, PosterUrl= movie.PosterUrl, Title= movie.Title });
            }
            return movieCards;
        }
        public async Task<IEnumerable<MovieCardResponseModel>> GetMoviesByGenre(int genreId)
        {
            var movies = await _movieRepository.GetMoviesByGenreId(genreId);
            var movieCards = new List<MovieCardResponseModel>();
            foreach (var movie in movies)
            {
                movieCards.Add(new MovieCardResponseModel { Id = movie.Id, PosterUrl = movie.PosterUrl, Title = movie.Title });
            }
            return movieCards;
        }
        public async Task<IEnumerable<ReviewRequestModel>> GetReviews(int id)
        {
            var movie = await _movieRepository.GetById(id);
            var reviews = new List<ReviewRequestModel>();
            foreach (var review in movie.Reviews)
            {
                reviews.Add(new ReviewRequestModel { MovieId = review.MovieId, Rating = review.Rating, ReviewText = review.ReviewText, UserId = review.UserId });
            }
            return reviews;
        }
    }
}
