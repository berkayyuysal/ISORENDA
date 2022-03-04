using System;
using Core.Entities;

namespace Entities.Concrete
{
    public class Company : IEntity
    {
        public Guid CompanyId { get; set; }
        public Guid UserId { get; set; }
        public string TaxNumber { get; set; }
        public string Name { get; set; }
    }
}