using System.Collections.Generic;

namespace Twenty.Data.Domain
{
    public class Choice : Entity
    {
        public string Text { get; set; }
        
        public bool IsAnswer { get; set; }

        public long QuestionId { get; set; }
        public Question Question { get; set; }

        public ICollection<PlayerChoice> PlayerChoices { get; set; } = new List<PlayerChoice>();
    }
}