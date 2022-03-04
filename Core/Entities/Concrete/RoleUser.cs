using System;

namespace Core.Entities.Concrete
{
    public class RoleUser : IEntity
    {
        public Guid RoleUserId { get; set; }
        public Guid UserId { get; set; }
        public Guid RoleId { get; set; }
        public DateTime InsertDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public Guid UpdateUserId { get; set; }
    }
}