using System;
using System.Collections.Generic;

namespace Core.Entities.Concrete
{
    public class Basket : IEntity
    {
        public Basket()
        {
            BasketCourseMentors = new HashSet<BasketCourseMentor>();
            Orders = new HashSet<Order>();
        }

        public Guid BasketId { get; set; }
        public Guid UserId { get; set; }
        public bool Status { get; set; }

        public virtual User User { get; set; }
        public virtual ICollection<BasketCourseMentor> BasketCourseMentors { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
