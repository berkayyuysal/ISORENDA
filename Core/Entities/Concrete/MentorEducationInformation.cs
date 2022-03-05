using System;
using System.Collections.Generic;

namespace Core.Entities.Concrete
{
    public class MentorEducationInformation : IEntity
    {
        public Guid MentorEducationInformationId { get; set; }
        public Guid MentorId { get; set; }
        public string UniversityName { get; set; }
        public string HighSchoolName { get; set; }
        public DateTime InsertDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public Guid UpdateUserId { get; set; }

        public virtual Mentor Mentor { get; set; }
    }
}
