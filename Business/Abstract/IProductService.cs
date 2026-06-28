using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IProductService
    {
        Task<IDataResult<List<Product>>> GetAllAsync();
        Task<IDataResult<List<Product>>> GetAllByCategoryId(int id);
        Task<IDataResult<List<Product>>> GetByUnitPriceAsync(decimal min,decimal max);
        Task<IDataResult<List<ProductDetailDto>>> GetProductDetailsAsync();
        Task<IDataResult<Product>> GetByIdAsync(int productId);
        Task<IResult> AddAsync(Product product);
        Task<IResult> RemoveAsync(Product product);
       
    }
}
