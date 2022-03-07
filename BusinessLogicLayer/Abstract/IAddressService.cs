using System;
using System.Collections.Generic;
using Core.Entities.Concrete;
using Core.Utilities.Results;

namespace BusinessLogicLayer.Abstract
{
    public interface IAddressService
    {
        IResult AddAddress(Address address, User user);
        IResult DeleteAddress(Address address);
        IDataResult<List<Address>> GetAddresses();
        IDataResult<List<Address>> GetAddressesByUserId(Guid id);
        IResult UpdateAddress(Address address);
    }
}
