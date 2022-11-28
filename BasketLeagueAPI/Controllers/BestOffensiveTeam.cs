using BasketLeagueAPI.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BasketLeagueAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BestOffensiveTeam : ControllerBase
    {
        private readonly BasketLeagueDbContext basketLeagueDbContext;

        public BestOffensiveTeam(BasketLeagueDbContext basketLeagueDbContext)
        {
            this.basketLeagueDbContext = basketLeagueDbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetOffenseExperts()
        {
            var teams = await basketLeagueDbContext.Teams.Select(x => new
            {
                Name = x.Name,
                Score = x.HomeGames
                .Select(x => x.HomeTeamScore)
                .FirstOrDefault() + x.HomeGames
                .Select(x => x.HomeTeamScore)
                .FirstOrDefault(),

            }).OrderByDescending(x => x.Score).Take(5).ToListAsync();

            return Ok(teams);
        }
    }
}
