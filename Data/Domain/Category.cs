using System.Collections.Generic;

namespace Twenty.Data.Domain
{
    public class Category : Entity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public long ParentId { get; set; }
        public Category Parent { get; set; }
        public ICollection<Category> SubCategories { get; set; } = new List<Category>();
        public ICollection<Topic> Topics { get; set; } = new List<Topic>();
    }
}