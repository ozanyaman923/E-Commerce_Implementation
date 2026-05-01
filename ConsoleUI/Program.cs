using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework.EfEntities;
using System;

namespace MyApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IProductService productService = new ProductManager(new EfProductDal());
            foreach (var product in productService.GetByUnitQuery())
            {
                Console.WriteLine(product.ProductName + " ------- " + product.UnitPrice);
            }
        }
    }
} 