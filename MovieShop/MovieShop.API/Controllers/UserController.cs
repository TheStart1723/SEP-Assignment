using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ApplicationCore.ServiceInterfaces;
using ApplicationCore.Models;

namespace MovieShop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpGet]
        [Route("{id:int}/movie/{moveId:int}/favorite")]
        public async Task<IActionResult> CheckFavorite(int id, int movieId)
        {
            var result = await _userService.CheckUserFavorite(id, movieId);
            if(!result) return NotFound();
            return Ok(result);
        }
        [HttpGet]
        [Route("{id:int}/purchases")]
        public async Task<IActionResult> GetPurchases(int id)
        {
            var purchases = await _userService.GetUserPurchasedMovies(id);
            if(!purchases.Any()) return NotFound();
            return Ok(purchases);
        }
        [HttpGet]
        [Route("{id:int}/favorites")]
        public async Task<IActionResult> GetFavorites(int id)
        {
            var favorites = await _userService.GetUserFavoritedMovies(id);
            if (!favorites.Any()) return NotFound();
            return Ok(favorites);
        }
        [HttpGet]
        [Route("{id:int}/reviews")]
        public async Task<IActionResult> GetReviews(int id)
        {
            var reviews = await _userService.GetUserReviews(id);
            if (!reviews.Any()) return NotFound();
            return Ok(reviews);
        }
        [HttpPost]
        [Route("purchase")]
        public async Task<IActionResult> Purchase([FromBody] PurchaseRequestModel model)
        {
            var id = await _userService.UserPurchase(model);
            if (id == -1) return Conflict();
            return Ok(id);

        }
        [HttpPost]
        [Route("favorite")]
        public async Task<IActionResult> Favorite([FromBody] FavoriteRequestModel model)
        {
            var id = await _userService.UserFavorite(model);
            if (id == -1) return Conflict();
            return Ok(id);
        }
        [HttpPost]
        [Route("unfavorite")]
        public async Task<IActionResult> Unfavorite([FromBody] FavoriteRequestModel model)
        {
            var result = await _userService.DeleteFavorite(model.UserId, model.MovieId);
            if (!result) return NotFound();
            return Ok(result);
        }
        [HttpPost]
        [Route("review")]
        public async Task<IActionResult> Review([FromBody] ReviewRequestModel model)
        {
            var result = await _userService.UserReview(model);
            if (!result) return Conflict();
            return Ok(result);
        }
        [HttpPut]
        [Route("review")]
        public async Task<IActionResult> UpdateReview([FromBody] ReviewRequestModel model)
        {
            var result = await _userService.EditReview(model);
            if(!result) return NotFound();
            return Ok(result);
        }
        [HttpDelete]
        [Route("{userId:int}/movie/{movieId:int}")]
        public async Task<IActionResult> DeleteFavorite(int userId, int movieId)
        {
            var result = await _userService.DeleteFavorite(userId, movieId);
            if (!result) return NotFound();
            return Ok(result);
        }
    }
}
