using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
using Microsoft.Extensions.Logging;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        IProductDal _productDal;
        ICategoryService _categoryService;
        

        public ProductManager(IProductDal productDal, ICategoryService categoryService)
        {
            _productDal = productDal;
            _categoryService = categoryService;
        }

        // [LogAspect] / [Validate] / [Remove Cache] [Transaction] [Performance] AOP aspect oriented programming
        [SecuredOperation("product.add,admin")]
        [ValidationAspect(typeof(ProductValidator))]
        public async Task<IResult> AddAsync(Product product)
        {
            IResult result = BusinessRules.Run(
                
                 await CheckIfNameAlreadyExists(product.ProductName));


            if (result !=null)
            {
                return result;
            }
            await _productDal.AddAsync(product);
            return new SuccessResult(Messages.ProductAdded);
        }

        public async Task<IDataResult<List<Product>>> GetAllAsync()
        {
            //if (DateTime.Now.Hour == 22)
            //{
            //    return new ErrorDataResult<List<Product>>(Messages.MaintenanceTime);
            //}
            return new SuccessDataResult<List<Product>>(await _productDal.GetAllAsync(), Messages.ProductsListed);

        }

        public async Task<IDataResult<List<Product>>> GetAllByCategoryId(int id)
        {
            return new SuccessDataResult<List<Product>>(await _productDal.GetAllAsync(p => p.CategoryId == id));
        }

        public async Task<IDataResult<Product>> GetByIdAsync(int productId)
        {
            return new SuccessDataResult<Product>(await _productDal.GetAsync(p => p.ProductId == productId));
        }

        public async Task<IDataResult<List<Product>>> GetByUnitPriceAsync(decimal min, decimal max)
        {
            return new SuccessDataResult<List<Product>>(await _productDal.GetAllAsync(p => p.UnitPrice >= min && p.UnitPrice <= max));
        }

        public async Task<IDataResult<List<ProductDetailDto>>> GetProductDetailsAsync()
        {
            if (DateTime.Now.Hour == 18)
            {
                return new ErrorDataResult<List<ProductDetailDto>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<ProductDetailDto>>(await _productDal.GetProductDetailsAsync());
        }

        public async Task<IResult> RemoveAsync(Product product)
        {
            await _productDal.DeleteAsync(product);
            return new SuccessResult(Messages.ProductRemoved);
        }
        private async Task<IResult> CheckIfProductCountOfCategoryCorrect(int categoryId)
        {
            var result = (await _productDal.GetAllAsync(p => p.CategoryId == categoryId)).Count();
            if (result >= 10)
            {
                return new ErrorResult(Messages.ProductCountOfCategoryError);
            }
            return new SuccessResult();
        }
        private async Task<IResult> CheckIfNameAlreadyExists(string productName)
        {
            var result = (await _productDal.GetAllAsync(p => p.ProductName == productName)).Any();
            if (result)
            {
                return new ErrorResult(Messages.NameAlreadyHave);
            }
            return new SuccessResult();
        }
    }
}