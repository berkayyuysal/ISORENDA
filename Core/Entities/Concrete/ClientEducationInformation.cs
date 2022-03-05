using System;
namespace Core.Entities.Concrete
{
    public class ClientEducationInformation : IEntity
    {
        public ClientEducationInformation()
        {
        }

        public Guid ClientEducationInformationId { get; set; }
        public Guid ClientId { get; set; }
        public string UniversityName { get; set; }
        public string HighSchoolName { get; set; }
        public DateTime InsertDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public Guid UpdateUserId { get; set; }

        public virtual Client Client { get; set; }
    }
}
