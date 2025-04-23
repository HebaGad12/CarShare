using CarShare.DTO;
using CarShare.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CarShare.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OwnerController : ControllerBase
    {
        private readonly OwnerService _ownerService;

        public OwnerController(OwnerService ownerService)
        {
            _ownerService = ownerService;
            
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] OwnerRegisterDto dto)
        {
            var result = await _ownerService.RegisterAsync(dto);
            return Ok(new { message = result });
        }
        [HttpPost("create-car-post")]
        public async Task<IActionResult> CreateCarPost([FromBody] CarPostCreateDto dto)
        {
            var result = await _ownerService.CreateCarPostAsync(dto);
            return Ok(new { message = result });
        }
        [HttpGet("MyCarPosts/{ownerId}")]
        public async Task<IActionResult> GetMyCarPosts(int ownerId)
        {
            try
            {
                var carPosts = await _ownerService.GetMyCarPostsAsync(ownerId);
                return Ok(carPosts);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
        [HttpPut("update")]
        public async Task<IActionResult> UpdateCarPost([FromBody] CarPostUpdateDto dto)
        {
            var result = await _ownerService.UpdateCarPostAsync(dto);

            if (!result)
                return NotFound("Car post not found");

            return Ok("Car post updated successfully");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCarPost(int id)
        {
            var deleted = await _ownerService.DeleteCarPostAsync(id);
            if (!deleted)
                return NotFound("Car post not found.");

            return Ok("Car post deleted successfully.");
        }

    }
}
