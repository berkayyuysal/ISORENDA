using System;
using System.Collections.Generic;

namespace Core.Entities.Concrete
{
    public class Client : IEntity
    {
        public Client()
        {
            BasketClients = new HashSet<BasketClient>();
            ClientEducationInformations = new HashSet<ClientEducationInformation>();
            CourseMentorClients = new HashSet<CourseMentorClient>();
            FileAuthenticates = new HashSet<FileAuthenticate>();
            ParentClients = new HashSet<ParentClient>();
        }

        public Guid ClientId { get; set; }
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
        public virtual ICollection<BasketClient> BasketClients { get; set; }
        public virtual ICollection<ClientEducationInformation> ClientEducationInformations { get; set; }
        public virtual ICollection<CourseMentorClient> CourseMentorClients { get; set; }
        public virtual ICollection<FileAuthenticate> FileAuthenticates { get; set; }
        public virtual ICollection<ParentClient> ParentClients { get; set; }
    }
}
