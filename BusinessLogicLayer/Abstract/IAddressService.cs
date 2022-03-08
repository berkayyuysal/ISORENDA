using System;
using System.Collections.Generic;
using Core.Entities.Concrete;
using Core.Utilities.Results;

namespace BusinessLogicLayer.Abstract
{
    public interface IAddressService
    {
        IResult Add(Address address, User user);
        IResult Update(Address address);
        IResult Delete(Address address);
        IDataResult<List<Address>> GetAddresses();
        IDataResult<Address> GetAddressById(Guid addressId);
        IDataResult<List<Address>> GetAddressesByUserId(Guid userId);
    }
}
