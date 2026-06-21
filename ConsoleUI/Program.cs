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
            IProductService productManager = new ProductManager(new EfProductDal(),new CategoryManager());
            var result = productManager.GetProductDetails();
            if(result.Success ) 
            {
                foreach (var product in result.Data)
                {
                    Console.WriteLine(product.ProductName+ "/"+ product.CategoryName);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }
    }
} 