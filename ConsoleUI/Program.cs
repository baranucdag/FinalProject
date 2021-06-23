using Business.Concrete;
using DataAcces.Concrete.EntityFramework;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //ProductTest();

            //CategoryTest();

            JoinTest();

        }

        private static void JoinTest()
        {
            ProductManager productManager1 = new ProductManager(new EFProductDal());            //
            foreach (var itemss in productManager1.GetProductDetails())
            {
                Console.WriteLine(itemss.ProductName + "  " + itemss.CategoryName + itemss.UnitsInStock);
            }
        }

        private static void CategoryTest()
        {
            CategoryManager categoryManager = new CategoryManager(new EFCategoryDal());
            foreach (var categories in categoryManager.GetAll())
            {
                Console.WriteLine(categories.CategoryName);
            }
        }

        private static void ProductTest()
        {
            ProductManager productManager = new ProductManager(new EFProductDal());  //Previous data source was InMemoryProductDal.
            foreach (var product in productManager.GetAll())                         //We changed data source only by change 1 place(EFProductdal)
            {
                Console.WriteLine(product.ProductName);
            }
        }
    }
}
