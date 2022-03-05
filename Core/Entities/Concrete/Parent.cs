using System;
using System.Collections.Generic;
using Core.Entities.Concrete;


namespace Core.Entities.Concrete
{
    public class Parent : IEntity
    {
        public Parent()
        {
            ParentClients = new HashSet<ParentClient>();
        }

        public Guid ParentId { get; set; }
        public Guid UserId { get; set; }
        public string IdentityNumber { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public int Gender { get; set; }
        public bool MaritalStatus { get; set; }
        public DateTime RealBirthDate { get; set; }
        public DateTime BirthDateOnIdentity { get; set; }

        public virtual User User { get; set; }
        public virtual ICollection<ParentClient> ParentClients { get; set; }
    }
}
