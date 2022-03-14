using System;
using System.Collections.Generic;
using BusinessLogicLayer.Abstract;
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

        public IResult Add(Address address, User user)
        {
            address.UserId = user.UserId;
            _addressDal.Add(address);
            return new SuccessResult("Adres eklendi");
        }

        public IResult Update(Address address)
        {
            BusinessRules.Run(AddressIsChanged(address));

            return new SuccessResult("Adres güncellendi.");
        }

        public IResult Delete(Address address)
        {
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

        private IResult AddressIsChanged(Address address)
        {
            var oldAddress = _addressDal.GetById(address.AddressId);

            if (oldAddress.Detail != address.Detail)
            {
                return new SuccessResult();
            }
            return new ErrorResult();
        }
    }
}
