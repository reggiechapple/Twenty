using System.Collections.Generic;
using Twenty.Data.Domain;

namespace Twenty.Data.Identity
{
    public class Player : Profile
    {
        public string ProfilePhoto { get; set; }

        public bool Banned { get; set; }
        
        public ICollection<Game> GamesPlayed { get; set; } = new List<Game>();
        public ICollection<PlayerChoice> Choices { get; set; } = new List<PlayerChoice>();
        public ICollection<Team> TeamsOrganized { get; set; } = new List<Team>();
        public ICollection<TeamPlayer> Teams { get; set; } = new List<TeamPlayer>();
    }
}