using ApplicationCore.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;

namespace MovieShopMVC.Controllers
{
    public class MoviesController : Controller
    {
        private readonly IMovieService _movieService;
        public MoviesController(IMovieService movieService)
        {
            _movieService = movieService;
        }
        public IActionResult Details(int id)
        {
            var movieDetails = _movieService.GetMovieDetailsById(id);   
            return View(movieDetails);
        }
    }
}
