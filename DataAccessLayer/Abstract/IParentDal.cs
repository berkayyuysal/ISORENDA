using System;
using System.Collections.Generic;
using Core.DataAccess;
using Core.Entities.Concrete;

namespace DataAccessLayer.Abstract
{
    public interface IParentDal : IEntityRepository<Parent>
    {
        List<Parent> GetParentsWithUserInformation();
        Parent GetOneParentWithUserInformations(Guid parentId);
    }
}
