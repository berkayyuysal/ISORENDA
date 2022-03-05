using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Core.Entities.Concrete
{
    public class FileAuthenticate : IEntity
    {
        public Guid FileAuthenticateId { get; set; }
        public Guid FileId { get; set; }
        public Guid MentorId { get; set; }
        public Guid ClientId { get; set; }

        public virtual Client Client { get; set; }
        public virtual File File { get; set; }
        public virtual Mentor Mentor { get; set; }
    }
}
