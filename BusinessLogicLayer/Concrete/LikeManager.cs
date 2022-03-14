using System;
using System.Collections.Generic;
using BusinessLogicLayer.Abstract;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using DataAccessLayer.Abstract;

namespace BusinessLogicLayer.Concrete
{
    public class LikeManager : ILikeService
    {
        ILikeDal _likeDal;
        public LikeManager(ILikeDal likeDal)
        {
            _likeDal = likeDal;
        }

        public IResult Add(Like like)
        {
            _likeDal.Add(like);
            return new SuccessResult();
        }

        public IResult Update(Like like)
        {
            _likeDal.Update(like);
            return new SuccessResult();
        }

        public IResult Delete(Like like)
        {
            like.Status = false;
            _likeDal.Update(like);
            return new SuccessResult();
        }

        public IDataResult<List<Like>> GetLikes()
        {
            var result = _likeDal.GetAll();
            if (result != null)
            {
                return new SuccessDataResult<List<Like>>(result);
            }
            return new ErrorDataResult<List<Like>>();
        }

        public IDataResult<Like> GetLikeById(Guid likeId)
        {
            var result = _likeDal.GetById(likeId);
            if (result != null)
            {
                return new SuccessDataResult<Like>(result);
            }
            return new ErrorDataResult<Like>();
        }
    }
}
