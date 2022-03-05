using System;
using System.Collections.Generic;
using Core.Entities.Concrete;


namespace Core.Entities.Concrete
{
    public class Like : IEntity
    {
        public Guid LikeId { get; set; }
        public Guid PostId { get; set; }
        public Guid UserId { get; set; }
        public DateTime LikeDate { get; set; }
        public bool Status { get; set; }

        public virtual Post Post { get; set; }
        public virtual User User { get; set; }
    }
}
