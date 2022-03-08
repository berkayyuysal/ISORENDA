using System;
using System.Collections.Generic;
using BusinessLogicLayer.Abstract;
using Core.Aspects.Autofac.Transaction;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using DataAccessLayer.Abstract;
using Entities.DTOs;

namespace BusinessLogicLayer.Concrete
{
    public class ClientManager : IClientService
    {
        IClientDal _clientDal;
        IUserService _userService;

        public ClientManager(IClientDal clientDal, IUserService userService)
        {
            _clientDal = clientDal;
            _userService = userService;
        }

        //[TransactionScopeAspect]
        public IResult Add(Client client)
        {
            _clientDal.Add(client);
            return new SuccessResult();
        }

        public IResult Update(Client client)
        {
            _clientDal.Update(client);
            return new SuccessResult();
        }

        public IResult Delete(Client client)
        {
            var takenClient = _clientDal.GetById(client.ClientId);
            var user = _userService.GetUserById(takenClient.UserId);
            user.Data.Status = false;
            _userService.Delete(user.Data);
            return new SuccessResult( takenClient.FirstName + " adlı " +"kullanıcı silindi");
        }

        public IDataResult<Client> GetClientById(Guid clientId)
        {
            var result = _clientDal.GetById(clientId);
            if (result != null)
            {
                return new SuccessDataResult<Client>(result);
            }
            return new ErrorDataResult<Client>();
        }

        public IDataResult<Client> GetClientByUserId(Guid userId)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Client>> GetClients()
        {
            var result = _clientDal.GetAll();
            if (result != null)
            {
                return new SuccessDataResult<List<Client>>(result);
            }
            return new ErrorDataResult<List<Client>>();
        }
    }
}
