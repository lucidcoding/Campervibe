using Campervibe.Domain.Common;
using System;

namespace Campervibe.Domain.Entities
{
    public class PermissionRole : Entity<Guid>
    {
        public virtual Permission Permission { get; set; }
        public virtual Role Role { get; set; }
    }
}
