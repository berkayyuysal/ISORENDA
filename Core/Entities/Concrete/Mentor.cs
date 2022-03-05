using System;
using System.Collections.Generic;
using Core.Entities.Concrete;


namespace Core.Entities.Concrete
{
    public class Mentor : IEntity
    {
        public Mentor()
        {
            CommentMentors = new HashSet<CommentMentor>();
            CourseMentors = new HashSet<CourseMentor>();
            FileAuthenticates = new HashSet<FileAuthenticate>();
            MentorEducationInformations = new HashSet<MentorEducationInformation>();
            Posts = new HashSet<Post>();
        }

        public Guid MentorId { get; set; }
        public Guid UserId { get; set; }
        public string IdentityNumber { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public int Gender { get; set; }
        public bool MaritalStatus { get; set; }
        public DateTime RealBirthDate { get; set; }
        public DateTime BirthDateOnIdentity { get; set; }

        public virtual User User { get; set; }
        public virtual ICollection<CommentMentor> CommentMentors { get; set; }
        public virtual ICollection<CourseMentor> CourseMentors { get; set; }
        public virtual ICollection<FileAuthenticate> FileAuthenticates { get; set; }
        public virtual ICollection<MentorEducationInformation> MentorEducationInformations { get; set; }
        public virtual ICollection<Post> Posts { get; set; }
    }
}
