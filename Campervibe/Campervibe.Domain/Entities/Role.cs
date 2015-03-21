using Campervibe.Domain.Common;
using System;
using System.Collections.Generic;

namespace Campervibe.Domain.Entities
{
    public class Role : Entity<Guid>
    {
        public virtual string Description { get; set; }
        public virtual string RoleName { get; set; }
        public virtual ICollection<PermissionRole> PermissionRoles { get; set; }
    }
}
