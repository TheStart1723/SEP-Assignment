using ApplicationCore.ServiceInterfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace MovieShopMVC.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        //Filters
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpGet]
        public async Task<IActionResult> Purchases()
        {
            var userId = Convert.ToInt32(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
            var purchases = _userService.GetUserPurchasedMovies(userId);
            return View(purchases);
        }

        [HttpGet]
        public async Task<IActionResult> Favorites()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Profile()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> EditPorfile()
        {
            return View();
        }
    }
}
