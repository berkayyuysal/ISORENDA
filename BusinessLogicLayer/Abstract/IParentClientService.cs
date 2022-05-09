using System;
using System.Collections.Generic;
using Core.Entities.Concrete;
using Core.Utilities.Results;

namespace BusinessLogicLayer.Abstract
{
    public interface IParentClientService
    {
        IResult Add(ParentClient parentClient);
        IResult Update(ParentClient parentClient);
        IResult Delete(ParentClient parentClient);
        IDataResult<List<ParentClient>> GetParentClients();
        IDataResult<ParentClient> GetParentClientById(Guid parentClientId);
    }
}
