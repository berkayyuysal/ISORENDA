using Core.Entities.Concrete;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogicLayer.Concrete.CategoryProcesses
{
    public partial class CategoryManager
    {
        private IResult CheckIsCategoryChanged(Category category)
        {
            var oldCategory = _categoryDal.GetById(category.CategoryId);

            if (oldCategory.Name != category.Name || oldCategory.CategoryParentId != category.CategoryParentId)
            {
                return new SuccessResult();
            }
            return new ErrorResult("Hey Developer! Update butonunu inaktif olarak ayarlamayı unuttun.");
        }

        private IResult CheckIsCategoryExists(Category category)
        {
            var categoryResult = _categoryDal.GetOne(c => c.Name == category.Name && c.CategoryParentId == category.CategoryParentId);
            if (categoryResult != null)
            {
                return new ErrorResult("Böyle bir kategori bulunmaktadır.");
            }
            return new SuccessResult();
        }

        private IResult CheckIsCategoryDeleted(Category category)
        {
            var categoryResult = _categoryDal.GetOne(c => c.CategoryId == category.CategoryId);
            if (!categoryResult.Status)
            {
                return new ErrorResult("Böyle bir adres bulunamamaktadır.");
            }
            return new SuccessResult();
        }
    }
}
