using System;
using Core.Entities;

namespace Entities.DTOs
{
    public class UserForRegisterDto : IDto
    {
        public Guid UserId { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public bool Status { get; set; }
        public DateTime InsertDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public Guid UpdateUserId { get; set; }
        
    }
}