using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities.Concrete
{
    public class User : IEntity
    {
        public Guid UserId { get; set; }
        public string UserName { get; set; }
        public string UserLastName { get; set; }
        public string UserEmail { get; set; }
        public byte[] UserPasswordHash { get; set; }
        public byte[] UserPasswordSalt { get; set; }
        public bool UserStatus { get; set; }

    }
}
