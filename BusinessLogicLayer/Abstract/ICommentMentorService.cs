using System;
using System.Collections.Generic;
using Core.Entities.Concrete;
using Core.Utilities.Results;

namespace BusinessLogicLayer.Abstract
{
    public interface ICommentMentorService
    {
        IResult Add(CommentMentor commentMentor);
        IResult Update(CommentMentor commentMentor);
        IResult Delete(CommentMentor commentMentor);
        IDataResult<List<CommentMentor>> GetCommentMentors();
        IDataResult<CommentMentor> GetCommentMentorById(Guid commentMentorId);
    }
}
