using System;
using System.Collections.Generic;


namespace Core.Entities.Concrete
{
    public class FileMentor : IEntity
    {
        public Guid FileMentorId { get; set; }
        public Guid FileId { get; set; }
        public Guid MentorId { get; set; }

        public virtual File File { get; set; }
    }
}
