using System;

namespace Entities.Concrete
{
    public class ParentClient
    {
        public Guid ParentClientId { get; set; }
        public Guid ParentId { get; set; }
        public Guid ClientId { get; set; }
    }
}