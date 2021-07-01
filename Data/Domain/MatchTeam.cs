namespace Twenty.Data.Domain
{
    public class MatchTeam
    {
        public long MatchId { get; set; }
        public Match Match { get; set; }

        public long TeamId { get; set; }
        public Team Team { get; set; }
    }
}