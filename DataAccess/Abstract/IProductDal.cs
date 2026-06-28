using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    //Ürüne ait özel operasyonlar eklenir.
    public interface IProductDal :IEntityRepository<Product> 
    {
          Task<List<ProductDetailDto>> GetProductDetailsAsync();
    }
}
