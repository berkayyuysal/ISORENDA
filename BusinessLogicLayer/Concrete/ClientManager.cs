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
        IAuthService _authService;

        public ClientManager(IClientDal clientDal, IUserService userService, IAuthService authService)
        {
            _clientDal = clientDal;
            _userService = userService;
            _authService = authService;
        }

        [TransactionScopeAspect]
        public IResult Add(Client client, UserForRegisterDto userForRegisterDto)
        {
            var user = _authService.Register(userForRegisterDto).Data;
            client.UserId = user.UserId;
            client.User = user;

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

        public IDataResult<List<Client>> GetClients()
        {
            var result = _clientDal.GetAll();
            if (result != null)
            {
                return new SuccessDataResult<List<Client>>(result);
            }
            return new ErrorDataResult<List<Client>>();
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
            var user = _userService.GetUserById(userId).Data;
            var result = _clientDal.GetOne(u => u.UserId == user.UserId);
            if (result != null)
            {
                return new SuccessDataResult<Client>(result);
            }
            return new ErrorDataResult<Client>();
        }

        public IDataResult<List<Client>> GetClientsWithUserInformations()
        {
            var result = _clientDal.GetClientsWithUserInformation();
            if (result != null)
            {
                return new SuccessDataResult<List<Client>>(result);
            }
            return new ErrorDataResult<List<Client>>();
        }
    }
}
