using System;
using System.Collections.Generic;
using Core.Entities.Concrete;
using Core.Utilities.Results;

namespace BusinessLogicLayer.Abstract
{
    public interface ILikeService
    {
        IResult Add(Like like);
        IResult Delete(Like like);
        IDataResult<List<Like>> GetLikes();
        IDataResult<List<Like>> GetLikesByPostId(Guid postId);
        IDataResult<Like> GetLikeById(Guid likeId);
    }
}
