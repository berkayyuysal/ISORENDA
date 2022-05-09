using System;
using System.Collections.Generic;
using BusinessLogicLayer.Abstract;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using DataAccessLayer.Abstract;

namespace BusinessLogicLayer.Concrete.CommentMentorProcesses
{
    public class CommentMentorManager : ICommentMentorService
    {
        ICommentMentorDal _commentMentorDal;
        public CommentMentorManager(ICommentMentorDal commentMentorDal)
        {
            _commentMentorDal = commentMentorDal;
        }

        public IResult Add(CommentMentor commentMentor)
        {
            _commentMentorDal.Add(commentMentor);
            return new SuccessResult();
        }

        public IResult Update(CommentMentor commentMentor)
        {
            _commentMentorDal.Update(commentMentor);
            return new SuccessResult();
        }

        public IResult Delete(CommentMentor commentMentor)
        {
            _commentMentorDal.Delete(commentMentor);
            return new SuccessResult();
        }

        public IDataResult<CommentMentor> GetCommentMentorById(Guid commentMentorId)
        {
            var result = _commentMentorDal.GetById(commentMentorId);
            if (result != null)
            {
                return new SuccessDataResult<CommentMentor>(result);
            }
            return new ErrorDataResult<CommentMentor>(result);
        }

        public IDataResult<List<CommentMentor>> GetCommentMentors()
        {
            var result = _commentMentorDal.GetAll();
            if (result != null)
            {
                return new SuccessDataResult<List<CommentMentor>>(result);
            }
            return new ErrorDataResult<List<CommentMentor>>(result);
        }
    }
}
