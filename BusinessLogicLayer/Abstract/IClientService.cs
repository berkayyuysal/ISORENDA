using System;
using System.Collections.Generic;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using Entities.DTOs;

namespace BusinessLogicLayer.Abstract
{
    public interface IClientService
    {
        IResult Add(Client client, UserForRegisterDto userForRegisterDto);
        IResult Update(Client client);
        IResult Delete(Client client);
        IDataResult<List<Client>> GetClients();
        IDataResult<Client> GetClientById(Guid clientId);
        IDataResult<Client> GetClientByUserId(Guid userId);
        IDataResult<List<Client>> GetClientsWithUserInformations();
        IDataResult<Client> GetOneClientWithUserInformations(Guid clientId);
    }
}
