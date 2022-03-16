using System;
using System.Collections.Generic;
using Core.DataAccess;
using Core.Entities.Concrete;

namespace DataAccessLayer.Abstract
{
    public interface IClientDal : IEntityRepository<Client>
    {
        List<Client> GetClientsWithUserInformation();
        Client GetOneClientWithUserInformations(Guid clientId);
    }
}
