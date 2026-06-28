using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICategoryService
    {
        Task<IDataResult<List<Category>>> GetAllAsync();
        Task<IDataResult<Category>> GetByIdAsync(int categoryId);
    }
}
