﻿using ApplicationCore.Models;
using ApplicationCore.RepositoryInterfaces;
using ApplicationCore.ServiceInterfaces;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class GenreService: IGenreService
    {
        private readonly IGenreRepository _genreRepository;
        private readonly IMemoryCache _memoryCache;
        private static readonly string _genresCacheKey = "genres";
        private static readonly TimeSpan _defaultCacheDuration = TimeSpan.FromDays(7);
        public GenreService(IGenreRepository genreRepository, IMemoryCache memoryCache)
        {
            _genreRepository = genreRepository;
            _memoryCache = memoryCache;
        }
        public async Task<List<GenreModel>> GetAllGenres()
        {
            var genresFromCache = await _memoryCache.GetOrCreateAsync(_genresCacheKey, CacheFactory);
            return genresFromCache.OrderBy(g => g.Name).ToList();
        }

        private async Task<IEnumerable<GenreModel>> CacheFactory(ICacheEntry entry)
        {
            entry.SlidingExpiration = _defaultCacheDuration;
            var genres = await _genreRepository.GetAll();
            var genreModel = new List<GenreModel>();
            foreach (var genre in genres)
            {
                genreModel.Add(new GenreModel { Id = genre.Id, Name = genre.Name });
            }
            return genreModel;
        }
    }
}
