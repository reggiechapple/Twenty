using System;
using System.Collections.Generic;
using Twenty.Data.Enums;

namespace Twenty.Data.Domain
{
    public class Question : Entity
    {
        public string Text { get; set; }

        public Difficulty Difficulty { get; set; }

        public TimeSpan Time { get; set; }

        public long GameId { get; set; }
        public Game Game { get; set; }

        public ICollection<Choice> Choices { get; set; } = new List<Choice>();
        
    }
}