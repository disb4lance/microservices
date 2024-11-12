using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using repository;


namespace catalog.Presintations.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CurtainsController : ControllerBase
    {
        private readonly repositoryContext _context;

        public CurtainsController(repositoryContext context)
        {
            _context = context;
        }

        [HttpGet("catalog")]
        [ResponseCache(Duration = 60)]
        public async Task<IActionResult> GetCurtains()
        {
            var curtains = await _context.Curtains.ToListAsync();
            return Ok(curtains);
        }
    }
}
