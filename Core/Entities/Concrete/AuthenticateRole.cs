using System;

namespace Core.Entities.Concrete
{
    public class AuthenticateRole : IEntity
    {
        public Guid AuthenticateRoleId { get; set; }
        public Guid AuthenticateId { get; set; }
        public Guid RoleId { get; set; }
        public DateTime InsertDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public Guid UpdateUserId { get; set; }

        public virtual Authenticate Authenticate { get; set; }
        public virtual Role Role { get; set; }
    }
}