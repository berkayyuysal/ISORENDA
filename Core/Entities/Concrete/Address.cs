using System;

namespace Core.Entities.Concrete
{
    public class Address : IEntity
    {
        public Guid AddressId { get; set; }
        public Guid UserId { get; set; }
        public Guid CityId { get; set; }
        public Guid TownId { get; set; }
        public string Detail { get; set; }
        public bool Status { get; set; }
        public DateTime InsertDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public Guid UpdateUserId { get; set; }

        public virtual City City { get; set; }
        public virtual Town Town { get; set; }
        public virtual User User { get; set; }
    }
}
