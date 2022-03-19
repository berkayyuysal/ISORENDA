using System;
using System.Collections.Generic;
using Core.DataAccess;
using Core.Entities.Concrete;

namespace DataAccessLayer.Abstract
{
    public interface IMentorDal : IEntityRepository<Mentor>
    {
        List<Mentor> GetMentorsWithUserInformation();
        Mentor GetOneMentorWithUserInformations(Guid mentorId);
    }
}
