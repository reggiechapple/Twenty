using System;
using System.Collections.Generic;

namespace Twenty.Data.Domain
{
    public class Match : Entity
    {
        public DateTime Start { get; set; }

        // References
        public long HomeTeamId { get; set; }

        public Team HomeTeam { get; set; }

        public long AwayTeamId { get; set; }

        public Team AwayTeam { get; set; }

        public Team Winner { get; set; }
        public long? WinnerId { get; set; }

        public ICollection<Comment> Comments { get; set; } = new List<Comment>();

        public ICollection<Bet> Bets { get; set; } = new List<Bet>();
    }
}