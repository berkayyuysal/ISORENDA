using System;
using System.Collections.Generic;
using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using DataAccessLayer.Abstract;
using System.Linq;

namespace DataAccessLayer.Concrete.EntityFramework
{
    public class EfParentDal : EfEntityRepositoryBase<Parent, IsorendaContext>, IParentDal
    {
        public EfParentDal()
        {
        }

        public List<Parent> GetParentsWithUserInformation()
        {
            using (IsorendaContext context = new IsorendaContext())
            {
                var result = from parent in context.Parents
                             join user in context.Users
                             on parent.UserId equals user.UserId
                             select new Parent
                             {
                                 ParentId = parent.ParentId,
                                 UserId = parent.UserId,
                                 IdentityNumber = parent.IdentityNumber,
                                 FirstName = parent.FirstName,
                                 MiddleName = parent.MiddleName,
                                 LastName = parent.LastName,
                                 Gender = parent.Gender,
                                 MaritalStatus = parent.MaritalStatus,
                                 RealBirthDate = parent.RealBirthDate,
                                 BirthDateOnIdentity = parent.BirthDateOnIdentity,
                                 User = user
                             };

                return result.ToList();
            }
        }

        public Parent GetOneParentWithUserInformations(Guid parentId)
        {
            using (IsorendaContext context = new IsorendaContext())
            {
                var result = from parent in context.Parents
                             join user in context.Users
                             on parent.UserId equals user.UserId
                             where parent.ParentId.Equals(parentId)
                             select new Parent
                             {
                                 ParentId = parent.ParentId,
                                 UserId = parent.UserId,
                                 IdentityNumber = parent.IdentityNumber,
                                 FirstName = parent.FirstName,
                                 MiddleName = parent.MiddleName,
                                 LastName = parent.LastName,
                                 Gender = parent.Gender,
                                 MaritalStatus = parent.MaritalStatus,
                                 RealBirthDate = parent.RealBirthDate,
                                 BirthDateOnIdentity = parent.BirthDateOnIdentity,
                                 User = user
                             };
                return result.FirstOrDefault();
            }
        }
    }
}
