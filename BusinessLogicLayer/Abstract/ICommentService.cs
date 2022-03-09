using System;
using System.Collections.Generic;
using Core.Entities.Concrete;
using Core.Utilities.Results;

namespace BusinessLogicLayer.Abstract
{
    public interface ICommentService
    {
        IResult Add(Comment comment);
        IResult Update(Comment comment);
        IResult Delete(Comment comment);
        IDataResult<List<Comment>> GetComments();
        IDataResult<Comment> GetCommentById(Guid commentId);
        IDataResult<List<Comment>> GetCommentsByUserId(Guid userId);
    }
}
