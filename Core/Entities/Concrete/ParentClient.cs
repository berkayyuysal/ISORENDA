using System;
using System.Collections.Generic;

namespace Core.Entities.Concrete
{
    public class ParentClient : IEntity
    {
        public Guid ParentClientId { get; set; }
        public Guid ParentId { get; set; }
        public Guid ClientId { get; set; }

        public virtual Client Client { get; set; }
        public virtual Parent Parent { get; set; }
    }
}
