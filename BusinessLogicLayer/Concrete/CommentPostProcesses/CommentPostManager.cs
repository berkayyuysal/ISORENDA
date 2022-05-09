using System;
using System.Collections.Generic;
using BusinessLogicLayer.Abstract;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using DataAccessLayer.Abstract;

namespace BusinessLogicLayer.Concrete.CommentPostProcesses
{
    public class CommentPostManager : ICommentPostService
    {
        ICommentPostDal _commentPostDal;
        public CommentPostManager(ICommentPostDal commentPostDal)
        {
            _commentPostDal = commentPostDal;
        }

        public IResult Add(CommentPost commentPost)
        {
            _commentPostDal.Add(commentPost);
            return new SuccessResult();
        }

        public IResult Update(CommentPost commentPost)
        {
            _commentPostDal.Update(commentPost);
            return new SuccessResult();
        }

        public IResult Delete(CommentPost commentPost)
        {
            _commentPostDal.Delete(commentPost);
            return new SuccessResult();
        }

        public IDataResult<CommentPost> GetCommentPostById(Guid commentPostId)
        {
            var result = _commentPostDal.GetById(commentPostId);
            if (result != null)
            {
                return new SuccessDataResult<CommentPost>(result);
            }
            return new ErrorDataResult<CommentPost>(result);
        }

        public IDataResult<List<CommentPost>> GetCommentPosts()
        {
            var result = _commentPostDal.GetAll();
            if (result != null)
            {
                return new SuccessDataResult<List<CommentPost>>(result);
            }
            return new ErrorDataResult<List<CommentPost>>(result);
        }
    }
}
