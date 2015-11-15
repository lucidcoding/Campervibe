using Campervibe.Domain.Common;
using System;

namespace Campervibe.Domain.Entities
{
    public class Permission : Entity<Guid>
    {
        public virtual string Description { get; set; }
    }
}
