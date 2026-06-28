using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        ICategoryDal _categoryDal;
        

        async Task<IDataResult<List<Category>>> ICategoryService.GetAllAsync()
        {
            return new SuccessDataResult<List<Category>>(await _categoryDal.GetAllAsync());
        }

        async Task<IDataResult<Category>> ICategoryService.GetByIdAsync(int categoryId)
        {
            return new SuccessDataResult<Category>(await _categoryDal.GetAsync(c => c.CategoryId == categoryId));
        }
    }
}
