using System.Collections.Generic;
using Twenty.Data.Domain;

namespace Twenty.Data.Identity
{
    public class Member : Profile
    {
        public string ProfilePhoto { get; set; }

        public bool Banned { get; set; }

        public ICollection<UserBet> Bets { get; set; } = new List<UserBet>();
    }
}