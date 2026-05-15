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
            //foreach (var product in productService.GetAll())
            //{
            //    Console.WriteLine(product.ProductName + " ------- " + product.UnitPrice);
            //}
            //ICategoryService categoryService = new CategoryManager(new EfCategoryDal());
            //foreach (var category in categoryService.GetAll())
            //{
            //    Console.WriteLine(category.CategoryName);
            //}

            //foreach (var i in productService.GetProductDetails())
            //{
            //    Console.WriteLine(i.ProductName + "    "+ i.CategoryName);
            //}



            //Console.WriteLine("Ozan Yaman");
            foreach (var i in productService.GetByUnitPrice(50,200))
            {
                Console.WriteLine(i.ProductName + "    " + i.CategoryName);



            }
        }
    }
} 