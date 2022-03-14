using System;
using System.Collections.Generic;
using Core.Entities.Concrete;
using Core.Utilities.Results;

namespace BusinessLogicLayer.Abstract
{
    public interface IFileService
    {
        IResult Add(File file);
        IResult Update(File file);
        IResult Delete(File file);
        IDataResult<List<File>> GetFiles();
        IDataResult<File> GetFileById(Guid fileId);
    }
}
