using System;

namespace Twenty.Data
{
    public interface IEntity
    {
        long Id { get; set; }
        DateTime Created { get; set; }
        DateTime Updated { get; set; }
    }
}