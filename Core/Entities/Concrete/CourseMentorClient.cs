using System;
namespace Core.Entities.Concrete
{
    public class CourseMentorClient : IEntity
    {
        public CourseMentorClient()
        {
        }
        public Guid CourseMentorClientId { get; set; }
        public Guid CourseMentorId { get; set; }
        public Guid ClientId { get; set; }
        public DateTime InsertDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public Guid UpdateUserId { get; set; }

        public virtual Client Client { get; set; }
        public virtual CourseMentor CourseMentor { get; set; }
    }
}
