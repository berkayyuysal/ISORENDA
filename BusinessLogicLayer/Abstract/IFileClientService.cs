using System;
using System.Collections.Generic;
using Core.Entities.Concrete;
using Core.Utilities.Results;

namespace BusinessLogicLayer.Abstract
{
    public interface IFileClientService
    {
        IResult Add(FileClient fileClient);
        IResult Update(FileClient fileClient);
        IResult Delete(FileClient fileClient);
        IDataResult<List<FileClient>> GetFileClients();
        IDataResult<FileClient> GetFileClientById(Guid fileClientId);
    }
}
