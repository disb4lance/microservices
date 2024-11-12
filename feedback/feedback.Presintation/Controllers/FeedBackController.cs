using Entities.models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using repository;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;


namespace feedback.Presintation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeedBackController : ControllerBase
    {

        private RepositoryContext repositoryContext;
        public FeedBackController(RepositoryContext _repositoryContext) { 
            repositoryContext = _repositoryContext;
        }

        [HttpPost]
        //[Authorize]
        public async Task<IActionResult> AddFeedBack([FromBody] feedbackmodel _feedback)
        {
            var token = HttpContext.Request.Headers["Authorization"].ToString().Replace("Bearer ", "");
            var handler = new JwtSecurityTokenHandler();
            var jwtToken = handler.ReadJwtToken(token);

            var userId = jwtToken.Claims.First(claim => claim.Type == ClaimTypes.NameIdentifier).Value;
            _feedback.userId = Guid.Parse(userId);

            await repositoryContext.Feedbacks.AddAsync(_feedback);
            await repositoryContext.SaveChangesAsync();

            return Ok();
        }
    }
}
