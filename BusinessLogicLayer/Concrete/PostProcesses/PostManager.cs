using System;
using System.Collections.Generic;
using BusinessLogicLayer.Abstract;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Performance;
using Core.Aspects.Autofac.Transaction;
using Core.Aspects.Autofac.Validation;
using Core.Entities.Concrete;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccessLayer.Abstract;

namespace BusinessLogicLayer.Concrete.PostProcesses
{
    public partial class PostManager : IPostService
    {
        IPostDal _postDal;
        public PostManager(IPostDal postDal)
        {
            _postDal = postDal;
        }

        [TransactionScopeAspect]
        [ValidationAspect(typeof(PostValidator))]
        [CacheRemoveAspect("IPostService.Get")]
        [PerformanceAspect(20)]
        public IResult Add(Post post, Guid mentorId)
        {
            post.MentorId = mentorId;
            _postDal.Add(post);
            return new SuccessResult();
        }

        [TransactionScopeAspect]
        [ValidationAspect(typeof(PostValidator))]
        [CacheRemoveAspect("IPostService.Get")]
        [PerformanceAspect(20)]
        public IResult Update(Post post)
        {
            var businessRules = BusinessRules.Run(CheckIsPostChanged(post));
            if (businessRules != null)
            {
                new ErrorResult(businessRules.Message);
            }
            _postDal.Update(post);
            return new SuccessResult();
        }

        [TransactionScopeAspect]
        [CacheRemoveAspect("IPostService.Get")]
        [PerformanceAspect(20)]
        public IResult Delete(Post post)
        {
            var businessRules = BusinessRules.Run(CheckIsPostDeleted(post));
            if (businessRules == null)
            {
                return new ErrorResult(businessRules.Message);
            }

            post.Status = false;
            _postDal.Update(post);
            return new SuccessResult();
        }

        public IDataResult<List<Post>> GetPosts()
        {
            var result = _postDal.GetAll();
            if (result != null)
            {
                return new SuccessDataResult<List<Post>>(result);
            }
            return new ErrorDataResult<List<Post>>(result);
        }
           
        public IDataResult<Post> GetPostById(Guid postId)
        {
            var result = _postDal.GetById(postId);
            if (result != null)
            {
                return new SuccessDataResult<Post>(result);
            }
            return new ErrorDataResult<Post>(result);
        }

        public IDataResult<List<Post>> GetActivePosts()
        {
            var result = _postDal.GetAll(p => p.Status == true);
            if (result != null)
            {
                return new SuccessDataResult<List<Post>>(result);
            }
            return new ErrorDataResult<List<Post>>(result);
        }

        public IDataResult<List<Post>> GetPostsByMentorId(Guid mentorId)
        {
            var result = _postDal.GetAll(p => p.MentorId == mentorId);
            if (result != null)
            {
                return new SuccessDataResult<List<Post>>(result);
            }
            return new ErrorDataResult<List<Post>>(result);
        }
    }
}
