using System.Collections.Generic;
using Twenty.Data.Enums;

namespace Twenty.Data.Domain
{
    public class Topic : Entity
    {
        public string Title { get; set; }

        public Difficulty Difficulty { get; set; }

        public long CategoryId { get; set; }
        public Category Category { get; set; }

        public ICollection<Question> Questions { get; set; } = new List<Question>();
    }
}