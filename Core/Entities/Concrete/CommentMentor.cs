using System;
namespace Core.Entities.Concrete
{
    public class CommentMentor : IEntity
    {
        public CommentMentor()
        {
        }


        public Guid CommentMentorId { get; set; }
        public Guid CommentId { get; set; }
        public Guid MentorId { get; set; }

        public virtual Comment Comment { get; set; }
        public virtual Mentor Mentor { get; set; }
    }
}
