using System;
using System.Collections.Generic;

namespace Core.Entities.Concrete
{
    public class Town : IEntity
    {
        public Town()
        {
            Addresses = new HashSet<Address>();
        }

        public Guid TownId { get; set; }
        public Guid CityId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Address> Addresses { get; set; }
    }
}
