using System;
using System.Collections.Generic;
using BusinessLogicLayer.Abstract;
using BusinessLogicLayer.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Performance;
using Core.Aspects.Autofac.Transaction;
using Core.Aspects.Autofac.Validation;
using Core.Entities.Concrete;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccessLayer.Abstract;

namespace BusinessLogicLayer.Concrete.CategoryProcesses
{
    public partial class CategoryManager : ICategoryService
    {
        ICategoryDal _categoryDal;
        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        [PerformanceAspect(20)]
        [TransactionScopeAspect]
        [CacheRemoveAspect("IAuthenticateService.Get")]
        [ValidationAspect(typeof(CategoryValidator))]
        public IResult Add(Category category)
        {
            var businessRuleResults = BusinessRules.Run(CheckIsCategoryExists(category));
            if (businessRuleResults != null && category.Status == false)
            {
                category.Status = true;
                _categoryDal.Update(category);
                return new SuccessResult("Kategori eklendi");
            }

            if (businessRuleResults == null)
            {
                _categoryDal.Add(category);
                return new SuccessResult("Kategori Eklendi");
            }

            return new ErrorResult(businessRuleResults.Message);
        }

        [PerformanceAspect(20)]
        [TransactionScopeAspect]
        [CacheRemoveAspect("IAuthenticateService.Get")]
        [ValidationAspect(typeof(AuthenticateValidator))]
        public IResult Update(Category category)
        {
            var businessRuleResults = BusinessRules.Run(CheckIsCategoryChanged(category));
            if (businessRuleResults != null)
            {
                return new ErrorResult(businessRuleResults.Message);
            }
            _categoryDal.Update(category);
            return new SuccessResult("Kategori güncellendi.");
        }

        [PerformanceAspect(20)]
        [TransactionScopeAspect]
        [CacheRemoveAspect("IAuthenticateService.Get")]
        public IResult Delete(Category category)
        {
            var businessRuleResults = BusinessRules.Run(CheckIsCategoryDeleted(category));
            if (!businessRuleResults.IsSuccess)
            {
                return new ErrorResult(businessRuleResults.Message);
            }
            category.Status = false;
            _categoryDal.Update(category);
            return new SuccessResult("Kategori silindi.");
        }

        public IDataResult<List<Category>> GetCategories()
        {
            var result = _categoryDal.GetAll();
            if (result != null)
            {
                return new SuccessDataResult<List<Category>>(result);
            }
            return new ErrorDataResult<List<Category>>();
        }

        public IDataResult<Category> GetCategoryById(Guid categoryId)
        {
            var result = _categoryDal.GetById(categoryId);
            if (result != null)
            {
                return new SuccessDataResult<Category>(result);
            }
            return new ErrorDataResult<Category>();
        }

        public IDataResult<Category> GetCategoryByParentId(Guid categoryParentId)
        {
            var result = _categoryDal.GetOne(c => c.CategoryParentId == categoryParentId);
            if (result != null)
            {
                return new SuccessDataResult<Category>(result);
            }
            return new ErrorDataResult<Category>();
        }
    }
}
