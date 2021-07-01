using System;
using System.Collections.Generic;
using Twenty.Data.Identity;

namespace Twenty.Data.Domain
{
    public class Team : Entity
    {
        public string Name { get; set; }

        public string Nickname { get; set; }
        
        public string Logo { get; set; }

        public string Record { get; set; } = "0-0";

        public long OrganizerId { get; set; }
        public Player Organizer { get; set; }

        public ICollection<TeamPlayer> Players { get; set; } = new List<TeamPlayer>();

        public ICollection<Match> Wins { get; set; } = new List<Match>();

        public ICollection<MatchTeam> Matches { get; set; } = new List<MatchTeam>();
    }
}