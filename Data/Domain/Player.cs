using System;

namespace Twenty.Data.Domain
{
    public class Player : Entity
    {
        public string FullName { get; set; }

        public DateTime BirthDate { get; set; }

        public long? TeamId { get; set; }

        public Team Team { get; set; }
    }
}