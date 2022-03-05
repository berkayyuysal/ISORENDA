using System;
using System.Collections.Generic;

namespace Core.Entities.Concrete
{
    public class Company : IEntity
    {
        public Company()
        {
            BasketCompanies = new HashSet<BasketCompany>();
        }

        public Guid CompanyId { get; set; }
        public Guid UserId { get; set; }
        public string TaxNumber { get; set; }
        public string Name { get; set; }

        public virtual User User { get; set; }
        public virtual ICollection<BasketCompany> BasketCompanies { get; set; }
    }
}
