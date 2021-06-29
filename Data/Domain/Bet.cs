using System;
using System.Collections.Generic;

namespace Twenty.Data.Domain
{
    public class Bet : Entity
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public decimal WinningOdds { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime? CloseDate { get; set; }
        
        public bool? IsLive { get; set; }

        public long MatchId { get; set; }
        public Match Match { get; set; }

        public Team Winner { get; set; }
        public long? WinnerId { get; set; }

        public ICollection<UserBet> UserBets { get; set; }
    }
}