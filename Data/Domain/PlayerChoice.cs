using Twenty.Data.Identity;

namespace Twenty.Data.Domain
{
    public class PlayerChoice
    {
        public long PlayerId { get; set; }
        public Player Player { get; set; }

        public long ChoiceId { get; set; }
        public Choice Choice { get; set; }

        public long GameId { get; set; }
        public Game Game { get; set; }
    }
}