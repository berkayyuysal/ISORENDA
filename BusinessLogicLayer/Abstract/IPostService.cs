using System;
using System.Collections.Generic;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using Entities.DTOs;

namespace BusinessLogicLayer.Abstract
{
    public interface IPostService
    {
        IResult Add(Post post, Guid mentorId);
        IResult Update(Post post);
        IResult Delete(Post post);
        IDataResult<List<Post>> GetPosts();
        IDataResult<Post> GetPostById(Guid postId);
        IDataResult<List<Post>> GetActivePosts();
        IDataResult<List<Post>> GetPostsByMentorId(Guid mentorId);
    }
}
