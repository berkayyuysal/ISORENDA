using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Core.Entities;

namespace Entities.DTOs
{
    public class UserForLoginDto : IDto
    {
        public string? Email { get; set; }
        public string? Username { get; set; }
        public string Password { get; set; }
    }
}
