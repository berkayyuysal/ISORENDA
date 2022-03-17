using System;
using System.Collections.Generic;
using BusinessLogicLayer.Abstract;
using BusinessLogicLayer.Constants.Messages;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Performance;
using Core.Aspects.Autofac.Transaction;
using Core.Aspects.Autofac.Validation;
using Core.Entities.Concrete;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccessLayer.Abstract;
using Entities.DTOs;

namespace BusinessLogicLayer.Concrete.ClientProcesses
{
    public partial class ClientManager : IClientService
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
        [PerformanceAspect(20)]
        [CacheRemoveAspect("IClientService.Get")]
        [ValidationAspect(typeof(ClientValidator))]
        public IResult Add(Client client, UserForRegisterDto userForRegisterDto)
        {
            var businessRuleResults = BusinessRules.Run(CheckIsIdentityNumberExists(client.IdentityNumber));
            if (businessRuleResults != null)
            {
                return new ErrorResult(businessRuleResults.Message);
            }

            var user = _authService.Register(userForRegisterDto);
            if (!user.IsSuccess)
            {
                return new ErrorResult(user.Message);
            }

            client.UserId = user.Data.UserId;
            client.User = user.Data;

            _clientDal.Add(client);
            return new SuccessResult();
        }

        [TransactionScopeAspect]
        [CacheRemoveAspect("IClientService.Get")]
        [ValidationAspect(typeof(ClientValidator))]
        public IResult Update(Client client)
        {
            var businessRuleResults = BusinessRules.Run(CheckIsIdentityNumberExists(client.IdentityNumber));
            if (businessRuleResults != null)
            {
                return new ErrorResult(businessRuleResults.Message);
            }

            var updatedUserResult = _userService.Update(client.User);
            if (!updatedUserResult.IsSuccess)
            {
                return new ErrorResult(updatedUserResult.Message);
            }
            _clientDal.Update(client);
            return new SuccessResult();
        }

        [TransactionScopeAspect]
        [CacheRemoveAspect("IClientService.Get")]
        public IResult Delete(Client client)
        {
            var businessRuleResults = BusinessRules.Run(CheckIsClientDeleted(client));
            if (businessRuleResults != null)
            {
                return new ErrorResult(businessRuleResults.Message);
            }

            var userResult = _userService.GetUserById(client.UserId);
            if (!userResult.IsSuccess)
            {
                return new ErrorResult(userResult.Message);
            }

            var deletedUserResult = _userService.Delete(userResult.Data);
            if (!deletedUserResult.IsSuccess)
            {
                return new ErrorResult(deletedUserResult.Message);
            }

            return new SuccessResult(client.FirstName + " adlı kullanıcı silindi");
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

        public IDataResult<Client> GetOneClientWithUserInformations(Guid clientId)
        {
             var result = _clientDal.GetOneClientWithUserInformations(clientId);
            if (result != null)
            {
                return new SuccessDataResult<Client>(result);
            }
            return new ErrorDataResult<Client>();
        }
    }
}
