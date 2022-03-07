
using System;
using System.Collections.Generic;

namespace Core.Entities.Concrete
{
    public class Role : IEntity
    {
        public Role()
        {
            AuthenticateRoles = new HashSet<AuthenticateRole>();
            RoleUsers = new HashSet<RoleUser>();
        }

        public Guid RoleId { get; set; }
        public string Name { get; set; }
        public bool Status { get; set; }
        public DateTime? InsertDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public DateTime? UpdateUserId { get; set; }

        public virtual ICollection<AuthenticateRole> AuthenticateRoles { get; set; }
        public virtual ICollection<RoleUser> RoleUsers { get; set; }

    }
}
