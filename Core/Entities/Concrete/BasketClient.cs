using System;
using System.Collections.Generic;

namespace Core.Entities.Concrete
{
    public class BasketClient : IEntity
    {
        public BasketClient()
        {
            BasketCourseMentors = new HashSet<BasketCourseMentor>();
            Orders = new HashSet<Order>();
        }

        public Guid BasketClientId { get; set; }
        public Guid ClientId { get; set; }
        public bool Status { get; set; }

        public virtual Client Client { get; set; }
        public virtual ICollection<BasketCourseMentor> BasketCourseMentors { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
