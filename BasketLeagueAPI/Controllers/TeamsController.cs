using BasketLeagueAPI.Data;
using BasketLeagueAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BasketLeagueAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TeamsController : ControllerBase
    {

        private readonly BasketLeagueDbContext basketLeagueDbContext;

        public TeamsController(BasketLeagueDbContext basketLeagueDbContext)
        {
            this.basketLeagueDbContext = basketLeagueDbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTeams()
        {
            var teams = await basketLeagueDbContext.Teams.ToListAsync();

            return Ok(teams);
        }


    }
}
