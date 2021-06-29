using Twenty.Data.Identity;

namespace Twenty.Data.Domain
{
    public class UserBet : Entity
    {
        public bool? Correct { get; set; }

        public string Spread { get; set; }
        
        public decimal Amount { get; set; }

        public Team Selection { get; set; }
        public long? SelectionId { get; set; }

        public long MemberId { get; set; }
        public Member Member { get; set; }

        public long BetId { get; set; }
        public Bet Bet { get; set; }
    }
}