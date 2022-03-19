using System;
using System.Collections.Generic;
using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using DataAccessLayer.Abstract;
using System.Linq;

namespace DataAccessLayer.Concrete.EntityFramework
{
    public class EfCompanyDal : EfEntityRepositoryBase<Company, IsorendaContext>, ICompanyDal
    {
        public EfCompanyDal()
        {
        }

        public List<Company> GetClientsWithUserInformation()
        {
            using (IsorendaContext context = new IsorendaContext())
            {
                var result = from company in context.Companies
                             join user in context.Users
                             on company.UserId equals user.UserId
                             select new Company
                             {
                                 CompanyId = company.CompanyId,
                                 Name = company.Name,
                                 TaxNumber = company.TaxNumber,
                                 User = user
                             };

                return result.ToList();
            }
        }

        public Company GetOneClientWithUserInformations(Guid companyId)
        {
            using (IsorendaContext context = new IsorendaContext())
            {
                var result = from company in context.Companies
                             join user in context.Users
                             on company.UserId equals user.UserId
                             where company.CompanyId.Equals(companyId)
                             select new Company
                             {
                                 CompanyId = company.CompanyId,
                                 Name = company.Name,
                                 TaxNumber = company.TaxNumber,
                                 User = user
                             };

                return result.FirstOrDefault();
            }
        }
    }
}
