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

        public IResult AddAddress(Address address, User user)
        {
            address.UserId = user.UserId;
            _addressDal.Add(address);
            return new SuccessResult("Adres eklendi");
        }

        public IResult DeleteAddress(Address address)
        {
            address.Status = false;
            _addressDal.Update(address);
            return new SuccessResult("Adres silindi");
        }

        public IDataResult<List<Address>> GetAddressesByUserId(Guid id)
        {
            return new SuccessDataResult<List<Address>>(_addressDal.GetAll(a => a.UserId == id));
        }

        public IDataResult<List<Address>> GetAddresses()
        {
            return new SuccessDataResult<List<Address>>(_addressDal.GetAll());
        }

        public IResult UpdateAddress(Address address)
        {
            BusinessRules.Run(AddressIsChanged(address));
            return new SuccessResult("Adres güncellendi.");
        }

        private IResult AddressIsChanged(Address address)
        {
            var oldAddress = _addressDal.GetById(address.AddressId);

            if (oldAddress.Detail == address.Detail)
            {
                return new ErrorResult();
            }
            return new SuccessResult();
        }
    }
}
