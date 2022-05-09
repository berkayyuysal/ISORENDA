using System;
using System.Collections.Generic;

namespace Core.Entities.Concrete
{
    public class Order : IEntity
    {
        public Guid OrderId { get; set; }
        public Guid BasketId { get; set; }
        public bool BasketType { get; set; }
        public DateTime OrderDate { get; set; }
        public int Status { get; set; }
        public DateTime InsertDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public Guid UpdateUserId { get; set; }

        public virtual Basket Basket{ get; set; }
    }
}
