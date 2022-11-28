using System.ComponentModel.DataAnnotations;

namespace BasketLeagueAPI.Models
{
    public class MatchResult
    {
        [Key]
        public Guid Id { get; set; }

        public Guid HomeTeamId { get; set; }
        public Team HomeTeam { get; set; }

        public int HomeTeamScore { get; set; }

        public Guid AwayTeamId { get; set; }
        public Team AwayTeam { get; set; }

        public int AwayTeamScore { get; set; }
    }
}
