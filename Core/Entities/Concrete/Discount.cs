using System;
using System.Collections.Generic;

namespace Core.Entities.Concrete
{
    public class Discount : IEntity
    {
        public Discount()
        {
            DiscountCourseMentors = new HashSet<DiscountCourseMentor>();
        }

        public Guid DiscountId { get; set; }
        public int Percentage { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public DateTime InsertDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public Guid UpdateUserId { get; set; }

        public virtual ICollection<DiscountCourseMentor> DiscountCourseMentors { get; set; }
    }
}
