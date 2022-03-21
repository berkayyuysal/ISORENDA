using System;
using System.Collections.Generic;
using Core.Entities.Concrete;
using Core.Utilities.Results;

namespace BusinessLogicLayer.Abstract
{
    public interface ICategoryService
    {
        IResult Add(Category category);
        IResult Update(Category category);
        IResult Delete(Category category);
        IDataResult<List<Category>> GetCategories();
        IDataResult<Category> GetCategoryById(Guid categoryId);
        IDataResult<List<Category>> GetCategoriesByParentId(Guid categoryParentId);
    }
}
