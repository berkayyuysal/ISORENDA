
using System;

namespace Core.Entities.Concrete
{
    public class Role : IEntity
    {
        public Guid RoleId { get; set; }
        public string Name { get; set; }
        public DateTime? InsertDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public Guid? UpdateUserId { get; set; }

    }
}
