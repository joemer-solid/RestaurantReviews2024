using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RestaurantReviewsShared.Identity;

namespace RestaurantReviews2024.Server.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class TestUserController : ControllerBase
    {
        [HttpGet("all", Name = "GetAllRegisteredUsers")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetAllUsers()
        {
            return Ok(new[] { new TestUser()
                    { 
                        FirstName = "Kevin",
                        LastName = "Dockx",
                        Email = "kevin.dockx@gmail.com" 
                    }
            });
        }
    }
}
