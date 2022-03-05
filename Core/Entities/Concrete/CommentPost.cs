using System;
namespace Core.Entities.Concrete
{
    public class CommentPost : IEntity
    {
        public CommentPost()
        {
        }
        public Guid CommentPostId { get; set; }
        public Guid CommentId { get; set; }
        public Guid PostId { get; set; }

        public virtual Comment Comment { get; set; }
        public virtual Post Post { get; set; }
    }
}
