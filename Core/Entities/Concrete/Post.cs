using System;
using System.Collections.Generic;


namespace Core.Entities.Concrete
{
    public class Post : IEntity
    {
        public Post()
        {
            CommentPosts = new HashSet<CommentPost>();
            Likes = new HashSet<Like>();
        }

        public Guid PostId { get; set; }
        public Guid MentorId { get; set; }
        public string Title { get; set; }
        public string PostContent { get; set; }
        public bool Status { get; set; }
        public DateTime InsertDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public Guid UpdateUserId { get; set; }

        public virtual Mentor Mentor { get; set; }
        public virtual ICollection<CommentPost> CommentPosts { get; set; }
        public virtual ICollection<Like> Likes { get; set; }
    }
}
