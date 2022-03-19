using Core.Entities.Concrete;
using Core.Utilities.Results;
using System;

namespace BusinessLogicLayer.Concrete.AddressProcesses
{
    public partial class AddressManager
    {
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
