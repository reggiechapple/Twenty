using System;
using System.ComponentModel.DataAnnotations;

namespace Twenty.Data
{
    public abstract class Entity : IEntity
    {
        public long Id { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
    }
}