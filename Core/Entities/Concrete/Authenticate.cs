using System;

namespace Core.Entities.Concrete
{
    public class Authenticate : IEntity
    {
        public Guid AuthenticateId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public DateTime InsertDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public Guid UpdateUserId { get; set; }
    }
}