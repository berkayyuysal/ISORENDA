using System.Collections.Generic;
using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using DataAccessLayer.Abstract;
using System.Linq;

namespace DataAccessLayer.Concrete.EntityFramework
{
    public class EfUserDal : EfEntityRepositoryBase<User, IsorendaContext>, IUserDal
    {
        public List<Role> GetClaims(User user)
        {
            using (var context = new IsorendaContext())
            {
                var result = from roles in context.Roles
                             join userRoles in context.RoleUsers
                             on roles.RoleId equals userRoles.RoleId
                             where userRoles.UserId == user.UserId
                             select new Role { RoleId = roles.RoleId, Name = roles.Name };

                return result.ToList();
            }

        }
    }
}
