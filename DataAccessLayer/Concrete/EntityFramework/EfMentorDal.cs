using System;
using System.Collections.Generic;
using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using DataAccessLayer.Abstract;
using System.Linq;

namespace DataAccessLayer.Concrete.EntityFramework
{
    public class EfMentorDal : EfEntityRepositoryBase<Mentor, IsorendaContext>, IMentorDal
    {
        public EfMentorDal()
        {
        }

        public List<Mentor> GetMentorsWithUserInformation()
        {
            using (IsorendaContext context = new IsorendaContext())
            {
                var result = from mentor in context.Mentors
                             join user in context.Users
                             on mentor.UserId equals user.UserId
                             select new Mentor
                             {
                                 MentorId = mentor.MentorId,
                                 UserId = mentor.UserId,
                                 IdentityNumber = mentor.IdentityNumber,
                                 FirstName = mentor.FirstName,
                                 MiddleName = mentor.MiddleName,
                                 LastName = mentor.LastName,
                                 Gender = mentor.Gender,
                                 MaritalStatus = mentor.MaritalStatus,
                                 RealBirthDate = mentor.RealBirthDate,
                                 BirthDateOnIdentity = mentor.BirthDateOnIdentity,
                                 User = user
                             };

                return result.ToList();
            }
        }

        public Mentor GetOneMentorWithUserInformations(Guid mentorId)
        {
            using (IsorendaContext context = new IsorendaContext())
            {
                var result = from mentor in context.Mentors
                             join user in context.Users
                             on mentor.UserId equals user.UserId
                             where mentor.MentorId.Equals(mentorId)
                             select new Mentor
                             {
                                 MentorId = mentor.MentorId,
                                 UserId = mentor.UserId,
                                 IdentityNumber = mentor.IdentityNumber,
                                 FirstName = mentor.FirstName,
                                 MiddleName = mentor.MiddleName,
                                 LastName = mentor.LastName,
                                 Gender = mentor.Gender,
                                 MaritalStatus = mentor.MaritalStatus,
                                 RealBirthDate = mentor.RealBirthDate,
                                 BirthDateOnIdentity = mentor.BirthDateOnIdentity,
                                 User = user
                             };
                return result.FirstOrDefault();
            }
        }
    }
}
