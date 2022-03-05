using System;
using System.Collections.Generic;

namespace Core.Entities.Concrete
{
    public class Authenticate : IEntity
    {
        public Authenticate()
        {
            AuthenticateRoles = new HashSet<AuthenticateRole>();
        }

        public Guid AuthenticateId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public DateTime InsertDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public Guid UpdateUserId { get; set; }

        public virtual ICollection<AuthenticateRole> AuthenticateRoles { get; set; }
    }
}