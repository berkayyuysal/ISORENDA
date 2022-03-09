using System;
using System.Collections.Generic;
using BusinessLogicLayer.Abstract;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using DataAccessLayer.Abstract;

namespace BusinessLogicLayer.Concrete
{
    public class CommentManager : ICommentService
    {
        ICommentDal _commentDal;
        public CommentManager(ICommentDal commentDal)
        {
            _commentDal = commentDal;
        }

        public IResult Add(Comment comment)
        {
            _commentDal.Add(comment);
            return new SuccessResult();
        }

        public IResult Update(Comment comment)
        {
            _commentDal.Update(comment);
            return new SuccessResult();
        }

        public IResult Delete(Comment comment)
        {
            comment.Status = false;
            _commentDal.Update(comment);
            return new SuccessResult();
        }

        public IDataResult<List<Comment>> GetComments()
        {
            var result = _commentDal.GetAll();
            if (result != null)
            {
                return new SuccessDataResult<List<Comment>>(result);
            }
            return new ErrorDataResult<List<Comment>>();
        }

        public IDataResult<Comment> GetCommentById(Guid commentId)
        {
            var result = _commentDal.GetById(commentId);
            if (result != null)
            {
                return new SuccessDataResult<Comment>(result);
            }
            return new ErrorDataResult<Comment>();
        }

        public IDataResult<List<Comment>> GetCommentsByUserId(Guid userId)
        {
            var result = _commentDal.GetAll(c => c.UserId == userId);
            if (result != null)
            {
                return new SuccessDataResult<List<Comment>>(result);
            }
            return new ErrorDataResult<List<Comment>>();
        }
    }
}
