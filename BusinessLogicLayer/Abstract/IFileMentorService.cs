using System;
using System.Collections.Generic;
using Core.Entities.Concrete;
using Core.Utilities.Results;

namespace BusinessLogicLayer.Abstract
{
    public interface IFileMentorService
    {
        IResult Add(FileMentor fileMentor);
        IResult Update(FileMentor fileMentor);
        IResult Delete(FileMentor fileMentor);
        IDataResult<List<FileMentor>> GetFileMentors();
        IDataResult<FileMentor> GetFileMentorById(Guid fileMentorId);
    }
}
