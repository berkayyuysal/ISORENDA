using System;
using System.Collections.Generic;

namespace Core.Entities.Concrete
{
    public class Comment : IEntity
    {
        public Comment()
        {
            CommentMentors = new HashSet<CommentMentor>();
            CommentPosts = new HashSet<CommentPost>();
        }

        public Guid CommentId { get; set; }
        public Guid UserId { get; set; }
        public string CommentContent { get; set; }
        public DateTime Date { get; set; }
        public bool Status { get; set; }

        public virtual User User { get; set; }
        public virtual ICollection<CommentMentor> CommentMentors { get; set; }
        public virtual ICollection<CommentPost> CommentPosts { get; set; }
    }
}
