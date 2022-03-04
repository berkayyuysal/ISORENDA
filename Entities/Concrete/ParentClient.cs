using System;
using Core.Entities;

namespace Entities.Concrete
{
    public class ParentClient : IEntity
    {
        public Guid ParentClientId { get; set; }
        public Guid ParentId { get; set; }
        public Guid ClientId { get; set; }
    }
}