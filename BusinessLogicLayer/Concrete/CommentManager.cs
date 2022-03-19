using System;
using System.Collections.Generic;
using BusinessLogicLayer.Abstract;
using BusinessLogicLayer.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Transaction;
using Core.Aspects.Autofac.Validation;
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

        [TransactionScopeAspect]
        [ValidationAspect(typeof(CommentValidator))]
        public IResult Add(Comment comment)
        {
            _commentDal.Add(comment);
            return new SuccessResult();
        }

        [TransactionScopeAspect]
        [ValidationAspect(typeof(CommentValidator))]
        public IResult Update(Comment comment)
        {
            _commentDal.Update(comment);
            return new SuccessResult();
        }

        [TransactionScopeAspect]
        [ValidationAspect(typeof(CommentValidator))]
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
