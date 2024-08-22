using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RestaurantReviewsShared.Entities;

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
                    },
                    new TestUser()
                    {
                        FirstName = "Natalie",
                        LastName = "Mars",
                        Email = "natalie.mars@hotmail.com"
                    },
                    new TestUser()
                    {
                        FirstName = "Jamie",
                        LastName = "Benzy",
                        Email = "jamiebenzy@use.startmail.com"
                    }
            });
        }
    }
}
