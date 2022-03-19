using System;
using System.Collections.Generic;
using BusinessLogicLayer.Abstract;
using BusinessLogicLayer.BusinessAspects.Autofac;
using Core.Aspects.Autofac.Performance;
using Core.Aspects.Autofac.Transaction;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using DataAccessLayer.Abstract;

namespace BusinessLogicLayer.Concrete.LikeProcesses
{
    public class LikeManager : ILikeService
    {
        ILikeDal _likeDal;
        public LikeManager(ILikeDal likeDal)
        {
            _likeDal = likeDal;
        }

        [TransactionScopeAspect]
        [PerformanceAspect(20)]
        [SecuredOperation("client, mentor")]
        public IResult Add(Like like)
        {
            _likeDal.Add(like);
            return new SuccessResult();
        }

        [TransactionScopeAspect]
        [PerformanceAspect(20)]
        [SecuredOperation("client, mentor")]
        public IResult Delete(Like like)
        {
            like.Status = false;
            _likeDal.Update(like);
            return new SuccessResult();
        }

        [TransactionScopeAspect]
        [PerformanceAspect(20)]
        public IDataResult<List<Like>> GetLikes()
        {
            var result = _likeDal.GetAll();
            if (result != null)
            {
                return new SuccessDataResult<List<Like>>(result);
            }
            return new ErrorDataResult<List<Like>>();
        }

        [TransactionScopeAspect]
        [PerformanceAspect(20)]
        public IDataResult<List<Like>> GetLikesByPostId(Guid postId)
        {
            var result = _likeDal.GetAll(l => l.PostId == postId);
            if (result != null)
            {
                return new SuccessDataResult<List<Like>>(result);
            }
            return new ErrorDataResult<List<Like>>();
        }

        [TransactionScopeAspect]
        [PerformanceAspect(20)]
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
