using Business.Abstract;
using Business.Concrete;
using DataAcces.Concrete.EntityFramework;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {

            CategoryTest();

            //JoinTest();
            //ProductManager productManager = new ProductManager(new EFProductDal());
            //var resultProduct = productManager.GetAll();
            //foreach (var item in resultProduct.Data)
            //{
            //    Console.WriteLine("   "+item.ProductId+item.ProductName);
            //}

        }

        //private static void JoinTest()
        //{
        //    ProductManager productManager = new ProductManager(new EFProductDal());          
        //    var result = productManager.GetProductDetails();
        //    if (result.Succes==true)
        //    {
        //        foreach (var itemss in result.Data)
        //        {
        //            Console.WriteLine(itemss.ProductName + "/ " + itemss.CategoryName);
        //        }
        //    }
        //    else
        //    {
        //        Console.WriteLine(result.Message);
        //    }
            
           
        //}

        private static void CategoryTest()
        {
            CategoryManager categoryManager = new CategoryManager(new EFCategoryDal());
            foreach (var categories in categoryManager.GetAll())
            {
                Console.WriteLine(categories.CategoryName);
            }
        }

      
    }
}



// ProductTest();
//private static void ProductTest()
//{
//    ProductManager productManager = new ProductManager(new EFProductDal());  //Previous data source was InMemoryProductDal.
//                                                                             //We changed data source only by change 1 place(EFProductdal)
//    foreach (var product in productManager.GetAll().Data)                         
//    {
//        Console.WriteLine(product.ProductName);
//    }
//}