using BasketLeagueAPI.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BasketLeagueAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BestDefensiveTeam : ControllerBase
    {
        private readonly BasketLeagueDbContext basketLeagueDbContext;

        public BestDefensiveTeam(BasketLeagueDbContext basketLeagueDbContext)
        {
            this.basketLeagueDbContext = basketLeagueDbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetDefensiveExperts()
        {
            var teams = await basketLeagueDbContext.Teams.Select(x => new
            {
                Name = x.Name,
                Score = x.AwayGames
                .Select(x => x.HomeTeamScore)
                .FirstOrDefault() + x.HomeGames
                .Select(x => x.AwayTeamScore)
                .FirstOrDefault()

            }).OrderBy(x => x.Score).Take(5).ToListAsync();

            return Ok(teams);
        }
    }
}
