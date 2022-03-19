using System;
using System.Collections.Generic;
using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using DataAccessLayer.Abstract;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Concrete.EntityFramework
{
    public class EfClientDal : EfEntityRepositoryBase<Client, IsorendaContext>, IClientDal
    {
        public EfClientDal()
        {
        }

        public List<Client> GetClientsWithUserInformation()
        {
            using (IsorendaContext context = new IsorendaContext())
            {
                var result = from client in context.Clients
                join user in context.Users
                on client.UserId equals user.UserId
                select new Client
                {
                    ClientId = client.ClientId,
                    UserId = client.UserId,
                    IdentityNumber = client.IdentityNumber,
                    FirstName = client.FirstName,
                    MiddleName = client.MiddleName,
                    LastName = client.LastName,
                    Gender = client.Gender,
                    MaritalStatus = client.MaritalStatus,
                    RealBirthDate = client.RealBirthDate,
                    BirthDateOnIdentity = client.BirthDateOnIdentity,
                    User = user
                };

                return result.ToList();
            }
        }

        public Client GetOneClientWithUserInformations(Guid clientId)
        {
            using (IsorendaContext context = new IsorendaContext())
            {
                var result = from client in context.Clients
                             join user in context.Users
                             on client.UserId equals user.UserId
                             where client.ClientId.Equals(clientId)
                             select new Client
                             {
                                 ClientId = client.ClientId,
                                 UserId = client.UserId,
                                 IdentityNumber = client.IdentityNumber,
                                 FirstName = client.FirstName,
                                 MiddleName = client.MiddleName,
                                 LastName = client.LastName,
                                 Gender = client.Gender,
                                 MaritalStatus = client.MaritalStatus,
                                 RealBirthDate = client.RealBirthDate,
                                 BirthDateOnIdentity = client.BirthDateOnIdentity,
                                 User = user
                             };

                return result.FirstOrDefault();
            }
        }
    }
}
