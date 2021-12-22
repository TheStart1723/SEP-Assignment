using ApplicationCore.Models;
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
            var purchases = await _userService.GetUserPurchasedMovies(userId);
            return View(purchases);
        }

        [HttpGet]
        public async Task<IActionResult> Favorites()
        {
            var userId = Convert.ToInt32(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
            var favorites = await _userService.GetUserFavoritedMovies(userId);
            return View(favorites);
        }

        [HttpGet]
        public async Task<IActionResult> Profile()
        {
            var userId = Convert.ToInt32(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
            var userDetails = await _userService.GetUserDetails(userId);
            return View(userDetails);
        }

        [HttpGet]
        public IActionResult EditProfile()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> EditProfile(UserDetailsModel model)
        {
            var success = await _userService.EditUserProfile(model);
            if (!success)
            {
                return View("Error");
            }
            return LocalRedirect("~/");
        }
    }
}
