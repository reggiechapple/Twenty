using System;
using Twenty.Data.Identity;

namespace Twenty.Data.Domain
{
    public class Comment : Entity
    {
        public string Content { get; set; }

        public DateTime CreatedOn { get; set; }

        // References
        public long MatchId { get; set; }

        public Match Match { get; set; }

        public long MemberId { get; set; }

        public Member Member { get; set; }
    }
}