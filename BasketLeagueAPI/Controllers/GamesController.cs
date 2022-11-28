using BasketLeagueAPI.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace BasketLeagueAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GamesController : ControllerBase
    {

        private readonly BasketLeagueDbContext basketLeagueDbContext;

        public GamesController(BasketLeagueDbContext basketLeagueDbContext)
        {
            this.basketLeagueDbContext = basketLeagueDbContext;
        }




        [HttpGet]
        public async Task<IActionResult> GetAllGames()
        {
            var games = await basketLeagueDbContext.MatchResults.Select(x => new
            {
                AwayTeamName = x.AwayTeam.Name,
                HomeTeamName = x.HomeTeam.Name,
                AwayTeamScore = x.AwayTeamScore,
                HomeTeamScore = x.HomeTeamScore,
                MaxScore = x.HomeTeamScore + x.AwayTeamScore,

            }).ToListAsync();

            return Ok(games);
        }

        


    }
}
