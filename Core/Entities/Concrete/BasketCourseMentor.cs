using System;
namespace Core.Entities.Concrete
{
    public class BasketCourseMentor : IEntity
    {
        public BasketCourseMentor()
        {
        }

        public Guid BasketCourseMentorId { get; set; }
        public Guid BasketId { get; set; }
        public Guid CourseMentorId { get; set; }
        public bool BasketType { get; set; }

        public virtual Basket Basket { get; set; }
        public virtual CourseMentor CourseMentor { get; set; }
    }
}
