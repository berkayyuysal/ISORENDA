using System;
using System.Collections.Generic;

namespace Core.Entities.Concrete
{
    public class BasketCompany : IEntity
    {
        public BasketCompany()
        {
            BasketCourseMentors = new HashSet<BasketCourseMentor>();
            Orders = new HashSet<Order>();
        }

        public Guid BasketCompanyId { get; set; }
        public Guid CompanyId { get; set; }
        public bool Status { get; set; }

        public virtual Company Company { get; set; }
        public virtual ICollection<BasketCourseMentor> BasketCourseMentors { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
