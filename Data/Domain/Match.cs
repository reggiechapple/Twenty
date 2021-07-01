using System;
using System.Collections.Generic;

namespace Twenty.Data.Domain
{
    public class Match : Entity
    {
        public DateTime Start { get; set; }

        public int MaxTeams { get; set; } = 4;

        // References
        public Team Winner { get; set; }
        public long? WinnerId { get; set; }

        public ICollection<MatchTeam> Teams { get; set; } = new List<MatchTeam>();
    }
}