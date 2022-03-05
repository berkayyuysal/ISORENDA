using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities.Concrete
{
    public class User : IEntity
    {
        public User()
        {
            Addresses = new HashSet<Address>();
            Clients = new HashSet<Client>();
            Comments = new HashSet<Comment>();
            Companies = new HashSet<Company>();
            Likes = new HashSet<Like>();
            LoginLogs = new HashSet<LoginLog>();
            Mentors = new HashSet<Mentor>();
            Parents = new HashSet<Parent>();
            RoleUsers = new HashSet<RoleUser>();
        }

        public Guid UserId { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public bool Status { get; set; }
        public DateTime InsertDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public Guid UpdateUserId { get; set; }

        public virtual ICollection<Address> Addresses { get; set; }
        public virtual ICollection<Client> Clients { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Company> Companies { get; set; }
        public virtual ICollection<Like> Likes { get; set; }
        public virtual ICollection<LoginLog> LoginLogs { get; set; }
        public virtual ICollection<Mentor> Mentors { get; set; }
        public virtual ICollection<Parent> Parents { get; set; }
        public virtual ICollection<RoleUser> RoleUsers { get; set; }

    }
}
