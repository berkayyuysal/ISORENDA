using System;
using System.Collections.Generic;
using BusinessLogicLayer.Abstract;
using Core.Entities.Concrete;
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

        public IResult Add(Category category)
        {
            _categoryDal.Add(category);
            return new SuccessResult();
        }

        public IResult Update(Category category)
        {
            _categoryDal.Update(category);
            return new SuccessResult();
        }

        public IResult Delete(Category category)
        {
            category.Status = false;
            _categoryDal.Update(category);
            return new SuccessResult();
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
