using System;
using System.Collections.Generic;
using BusinessLogicLayer.Abstract;
using BusinessLogicLayer.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Performance;
using Core.Aspects.Autofac.Transaction;
using Core.Aspects.Autofac.Validation;
using Core.Entities.Concrete;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccessLayer.Abstract;

namespace BusinessLogicLayer.Concrete
{
    public class AddressManager : IAddressService
    {
        IAddressDal _addressDal;
        public AddressManager(IAddressDal addressDal)
        {
            _addressDal = addressDal;
        }

        [PerformanceAspect(20)]
        [TransactionScopeAspect]
        [CacheRemoveAspect("IAddressService.Get")]
        [ValidationAspect(typeof(AddressValidator))]
        public IResult Add(Address address, User user)
        {
            var businessRuleResults = BusinessRules.Run(CheckIsUserAddressExists(address, user.UserId));
            if (businessRuleResults != null && address.Status == false)
            {
                address.Status = true;
                _addressDal.Update(address);
                return new SuccessResult("Adres eklendi");
            }

            if (businessRuleResults == null)
            {
                address.UserId = user.UserId;
                _addressDal.Add(address);
                return new SuccessResult("Adres eklendi");
            }

            return new ErrorResult(businessRuleResults.Message);
        }

        [PerformanceAspect(20)]
        [TransactionScopeAspect]
        [CacheRemoveAspect("IAddressService.Get")]
        [ValidationAspect(typeof(AddressValidator))]
        public IResult Update(Address address)
        {
            var result = BusinessRules.Run(CheckIsAddressChanged(address));
            if (result != null)
            {
                return new ErrorResult(result.Message);
            }
            _addressDal.Update(address);
            return new SuccessResult("Adres güncellendi.");
        }

        [PerformanceAspect(20)]
        [TransactionScopeAspect]
        [CacheRemoveAspect("IAddressService.Get")]
        public IResult Delete(Address address)
        {
            var result = BusinessRules.Run(CheckIsAddressDeleted(address));

            if (!result.IsSuccess)
            {
                return new ErrorResult(result.Message);
            }

            address.Status = false;
            _addressDal.Update(address);
            return new SuccessResult("Adres silindi");
        }

        public IDataResult<List<Address>> GetAddresses()
        {
            var result = _addressDal.GetAll();
            if (result != null)
            {
                return new SuccessDataResult<List<Address>>(result);
            }

            return new ErrorDataResult<List<Address>>();
        }

        public IDataResult<Address> GetAddressById(Guid addressId)
        {
            var result = _addressDal.GetById(addressId);
            if (result != null)
            {
                return new SuccessDataResult<Address>(result);
            }

            return new ErrorDataResult<Address>();
        }

        public IDataResult<List<Address>> GetAddressesByUserId(Guid userId)
        {
            var result = _addressDal.GetAll(a => a.UserId == userId);
            if (result != null)
            {
                return new SuccessDataResult<List<Address>>(result);
            }

            return new ErrorDataResult<List<Address>>();
        }

        private IResult CheckIsAddressChanged(Address address)
        {
            var oldAddress = _addressDal.GetById(address.AddressId);

            if (oldAddress.Detail != address.Detail)
            {
                return new SuccessResult();
            }
            return new ErrorResult("Hey Developer! Update butonunu inaktif olarak ayarlamayı unuttun.");
        }

        private IResult CheckIsAddressDeleted(Address address)
        {
            var addressResult = _addressDal.GetOne(a => a.AddressId == address.AddressId);
            if (!addressResult.Status)
            {
                return new ErrorResult("Böyle bir adres bulunamamaktadır.");
            }
            return new SuccessResult();
        }

        private IResult CheckIsUserAddressExists(Address address, Guid userId)
        {
            var addressResult = _addressDal.GetOne(a => a.CityId == address.CityId && a.TownId == address.TownId && a.Detail == address.Detail && a.UserId == userId);
            if (addressResult != null)
            {
                return new ErrorResult("Böyle bir adres bulunmaktadır.");
            }
            return new SuccessResult();
        }
    }
}
