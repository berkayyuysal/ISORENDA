using System;
using System.Collections.Generic;

namespace Core.Entities.Concrete
{
    public class CourseMentor : IEntity
    {
        public CourseMentor()
        {
            BasketCourseMentors = new HashSet<BasketCourseMentor>();
            CourseMentorClients = new HashSet<CourseMentorClient>();
            DiscountCourseMentors = new HashSet<DiscountCourseMentor>();
        }

        public Guid CourseMentorId { get; set; }
        public Guid CourseId { get; set; }
        public Guid MentorId { get; set; }
        public decimal Price { get; set; }
        public DateTime InsertDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public Guid UpdateUserId { get; set; }

        public virtual Course Course { get; set; }
        public virtual Mentor Mentor { get; set; }
        public virtual ICollection<BasketCourseMentor> BasketCourseMentors { get; set; }
        public virtual ICollection<CourseMentorClient> CourseMentorClients { get; set; }
        public virtual ICollection<DiscountCourseMentor> DiscountCourseMentors { get; set; }
    }
}
