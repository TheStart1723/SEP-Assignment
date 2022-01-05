using ApplicationCore.Models;
using ApplicationCore.ServiceInterfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MovieShop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IAdminService _adminService;
        public AdminController(IAdminService adminService)
        {
            _adminService = adminService;
        }
        [HttpGet]
        [Route("purchases")]
        public async Task<IActionResult> GetPurchases()
        {
            var purchases = await _adminService.GetAllPurchases();
            if (!purchases.Any()) return NotFound();
            return Ok(purchases);
        }
        [HttpPost]
        [Route("movie")]
        public async Task<IActionResult> CreateMovie([FromBody] MovieCreateRequestModel model)
        {
            var id = await _adminService.CreateMovie(model);
            if(id == -1) return Conflict();
            return Created("/api/Admin/movie/{id}", id);
        }
        [HttpPut]
        [Route("movie")]
        public async Task<IActionResult> UpdateMovie([FromBody] MovieCreateRequestModel model)
        {
            var result = await _adminService.UpdateMovie(model);
            if (!result) return NoContent();
            return Ok(result);
        }
    }
}
