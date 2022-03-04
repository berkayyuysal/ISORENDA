using System;
using Core.Entities;

namespace Entities.Concrete
{
    public class Parent : IEntity
    {
        public Guid ParentId { get; set; }
        public Guid UserId { get; set; }
        public string IdentityNumber { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public int Gender { get; set; }
        public int MaritalStatus { get; set; }
        public DateTime RealBirthDate { get; set; }
        public DateTime BirthDateOnIdentity { get; set; }
    }
}