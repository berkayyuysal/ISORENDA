using System;
using System.Collections.Generic;
using Core.Entities.Concrete;


namespace Core.Entities.Concrete
{
    public class LoginLog : IEntity
    {
        public Guid LoginLogId { get; set; }
        public Guid UserId { get; set; }
        public DateTime LoginDate { get; set; }
        public DateTime? LogoutDate { get; set; }

        public virtual User User { get; set; }
    }
}
