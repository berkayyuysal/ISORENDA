using System;
using System.Collections.Generic;

namespace Core.Entities.Concrete
{
    public class City : IEntity
    {
        public City()
        {
            Addresses = new HashSet<Address>();
        }

        public Guid CityId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Address> Addresses { get; set; }
    }
}
