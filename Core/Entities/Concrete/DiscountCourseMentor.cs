using System;
using System.Collections.Generic;

namespace Core.Entities.Concrete
{
    public class DiscountCourseMentor : IEntity
    {
        public Guid DiscountCourseMentorId { get; set; }
        public Guid CourseMentorId { get; set; }
        public Guid DiscountId { get; set; }
        public bool Type { get; set; }

        public virtual CourseMentor CourseMentor { get; set; }
        public virtual Discount Discount { get; set; }
    }
}
