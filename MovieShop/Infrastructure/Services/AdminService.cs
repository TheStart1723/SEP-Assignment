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
    public class AdminService : IAdminService
    {
        private readonly IMovieRepository _movieRepository;
        private readonly IPurchaseRepository _purchaseRepository;
        public AdminService(IMovieRepository movieRepository, IPurchaseRepository purchaseRepository)
        {
            _movieRepository = movieRepository;
            _purchaseRepository = purchaseRepository;
        }
        public async Task<int> CreateMovie(MovieCreateRequestModel model)
        {
            var dbMovie = await _movieRepository.GetById(model.Id);
            if (dbMovie != null)
            {
                return -1;
            }
            var movie = new Movie
            {
                Id = model.Id,
                PosterUrl = model.PosterUrl,
                Title = model.Title,
                OriginalLanguage = model.OriginalLanguage,
                Overview = model.Overview,
                Budget = model.Budget,
                Revenue = model.Revenue,
                ReleaseDate = model.ReleaseDate,
                Tagline = model.Tagline,
                RunTime = model.RunTime,
                BackdropUrl = model.BackdropUrl,
                TmdbUrl = model.TmdbUrl,
                ImdbUrl = model.ImdbUrl,
                Price = model.Price
            };
            foreach (var movieGenres in model.Genres)
            {
                movie.GenresofMovie.Add(new MovieGenre { MovieId = model.Id, GenreId = movieGenres.Id });
            }
            var createdMovie = await _movieRepository.Add(movie);
            return createdMovie.Id;
        }

        public async Task<List<PurchaseRequestModel>> GetAllPurchases()
        {
            var purchases = await _purchaseRepository.GetAll();
            var purchaseModel = new List<PurchaseRequestModel>();
            foreach (var purchase in purchases)
            {
                purchaseModel.Add(new PurchaseRequestModel
                {
                    UserId = purchase.UserId,
                    PurchaseNumber = purchase.PurchaseNumber,
                    TotalPrice = purchase.TotalPrice,
                    PurchaseDateTime = purchase.PurchaseDateTime,
                    MovieId = purchase.MovieId
                });
            }
            return purchaseModel;
        }

        public async Task<bool> UpdateMovie(MovieCreateRequestModel model)
        {
            var dbMovie = await _movieRepository.GetById(model.Id);
            if (dbMovie == null)
                return false;
            var movie = new Movie
            {
                Id = model.Id,
                PosterUrl = model.PosterUrl,
                Title = model.Title,
                OriginalLanguage = model.OriginalLanguage,
                Overview = model.Overview,
                Budget = model.Budget,
                Revenue = model.Revenue,
                ReleaseDate = model.ReleaseDate,
                Tagline = model.Tagline,
                RunTime = model.RunTime,
                BackdropUrl = model.BackdropUrl,
                TmdbUrl = model.TmdbUrl,
                ImdbUrl = model.ImdbUrl,
                Price = model.Price
            };
            foreach (var movieGenres in model.Genres)
            {
                movie.GenresofMovie.Add(new MovieGenre { MovieId = model.Id, GenreId = movieGenres.Id });
            }
            await _movieRepository.Update(movie);
            return true;
        }
    }
}
