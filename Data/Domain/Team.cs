using System;
using System.Collections.Generic;

namespace Twenty.Data.Domain
{
    public class Team : Entity
    {
        public string Name { get; set; }

        public string Nickname { get; set; }

        public DateTime Founded { get; set; }

        public string Website { get; set; }
        
        public string Logo { get; set; }

        public string Record { get; set; }

        public ICollection<UserBet> UserBets { get; set; } = new List<UserBet>();

        public ICollection<Player> Players { get; set; } = new List<Player>();

        public ICollection<Match> Wins { get; set; } = new List<Match>();

        public ICollection<Match> AwayMatches { get; set; } = new List<Match>();

        public ICollection<Match> HomeMatches { get; set; } = new List<Match>();
    }
}