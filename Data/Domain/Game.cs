using System.Collections.Generic;
using Twenty.Data.Enums;
using Twenty.Data.Identity;

namespace Twenty.Data.Domain
{
    public class Game : Entity
    {
        public int MaxQuestions { get; set; }
        
        public int Right { get; set; }
        
        public int Wrong { get; set; }

        public int Score { get; set; }

        public bool Passed { get; set; }

        public bool Complete { get; set; }

        public Difficulty Difficulty { get; set; }

        public long TopicId { get; set; }
        public Topic Topic { get; set; }

        public long PlayerId { get; set; }
        public Player Player { get; set; }

        public ICollection<Question> Questions { get; set; } = new List<Question>();
        public ICollection<PlayerChoice> PlayerChoices { get; set; } = new List<PlayerChoice>();

    }
}