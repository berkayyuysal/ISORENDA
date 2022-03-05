using System;
using System.Collections.Generic;

namespace Core.Entities.Concrete
{
    public class FileClient : IEntity
    {
        public Guid FileClientId { get; set; }
        public Guid FileId { get; set; }
        public Guid ClientId { get; set; }

        public virtual File File { get; set; }
    }
}
