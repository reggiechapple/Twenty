using System.Collections.Generic;
using Twenty.Data.Domain;
using Twenty.Data.Identity;

namespace Twenty.Areas.Members.Models
{
    public class CircleViewModel
    {
        public Member Member { get; set; }
        public ICollection<Member> Circle { get; set; }
    }
}