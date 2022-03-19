using System;
using System.Collections.Generic;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using Entities.DTOs;

namespace BusinessLogicLayer.Abstract
{
    public interface IParentService
    {
        IResult Add(Parent parent, UserForRegisterDto userForRegisterDto);
        IResult Update(Parent parent);
        IResult Delete(Parent parent);
        IDataResult<List<Parent>> GetParents();
        IDataResult<Parent> GetParentById(Guid parentId);
        IDataResult<Parent> GetParentByUserId(Guid userId);
        IDataResult<List<Parent>> GetParentsWithUserInformations();
        IDataResult<Parent> GetOneParentWithUserInformations(Guid parentId);
    }
}
