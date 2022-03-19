using System;
using System.Collections.Generic;
using Core.DataAccess;
using Core.Entities.Concrete;

namespace DataAccessLayer.Abstract
{
    public interface ICompanyDal : IEntityRepository<Company>
    {
        List<Company> GetClientsWithUserInformation();
        Company GetOneClientWithUserInformations(Guid companyId);
    }
}
