using System.ComponentModel.DataAnnotations;

namespace BasketLeagueAPI.Models
{
    public class Team
    {
        [Key]
        public Guid Id { get; set; }

        public string? Name { get; set; }

        public ICollection<MatchResult> HomeGames { get; set; }

        public ICollection<MatchResult> AwayGames { get; set; }

    }
}
