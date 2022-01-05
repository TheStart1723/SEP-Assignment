using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationCore.Models;
using ApplicationCore.RepositoryInterfaces;
using ApplicationCore.ServiceInterfaces;

namespace Infrastructure.Services
{
    public class CastService : ICastService
    {
        private readonly ICastRepository _castRepository;
        public CastService(ICastRepository castRepository)
        {
            _castRepository = castRepository;  
        }
        public async Task<CastRequestModel> GetCastById(int id)
        {
            var cast = await _castRepository.GetById(id);
            var castDetails = new CastRequestModel
            {
                Id = cast.Id,
                Name = cast.Name,
                TmdbUrl = cast.TmdbUrl,
                ProfilePath = cast.ProfilePath,
            };
            return castDetails;
        }
    }
}
