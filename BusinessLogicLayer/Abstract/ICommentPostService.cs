using System;
using System.Collections.Generic;
using Core.Entities.Concrete;
using Core.Utilities.Results;

namespace BusinessLogicLayer.Abstract
{
    public interface ICommentPostService
    {
        IResult Add(CommentPost commentPost);
        IResult Update(CommentPost commentPost);
        IResult Delete(CommentPost commentPost);
        IDataResult<List<CommentPost>> GetCommentPosts();
        IDataResult<CommentPost> GetCommentPostById(Guid commentPostId);
    }
}
