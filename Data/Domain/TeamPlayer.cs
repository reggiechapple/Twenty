using Twenty.Data.Identity;

namespace Twenty.Data.Domain
{
    public class TeamPlayer
    {
        public long PlayerId { get; set; }
        public Player Player { get; set; }

        public long TeamId { get; set; }
        public Team Team { get; set; }
    }
}