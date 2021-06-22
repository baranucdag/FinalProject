using Business.Concrete;
using DataAcces.Concrete.EntityFramework;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            ProductManager productManager = new ProductManager(new EFProductDal());  //Previous data source was InMemoryProductDal.
            foreach (var product in productManager.GetAll())                         //We changed data source only by change 1 place(EFProductdal)
            {
                Console.WriteLine(product.ProductName);
            }
        }
    }
}
