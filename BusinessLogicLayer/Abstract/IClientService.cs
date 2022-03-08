using System;
using System.Collections.Generic;
using Core.Entities.Concrete;
using Core.Utilities.Results;

namespace BusinessLogicLayer.Abstract
{
    public interface IClientService
    {
        IResult Add(Client client);
        IResult Update(Client client);
        IResult Delete(Client client);
        IDataResult<List<Client>> GetClients();
        IDataResult<Client> GetClientById(Guid clientId);
        IDataResult<Client> GetClientByUserId(Guid userId);
    }
}
