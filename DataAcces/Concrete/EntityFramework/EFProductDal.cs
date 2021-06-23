using Core.DataAccess.EntityFramework;
using DataAcces.Abstract;
using Entities.Concrete;
using Entities.Conscrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAcces.Concrete.EntityFramework
{
    public class EFProductDal : EFEntityRepositoryBase<Product, NorthWindContext>, IProductDal
    {
        public List<ProductDetailDto> GetProductDetails()
        {
            using (NorthWindContext context= new NorthWindContext())
            {
                var result = from p in context.Products
                             join c in context.Categories               //join proccess
                             on p.CategoryId equals c.CategoryId
                             select new ProductDetailDto()
                             { CategoryName = c.CategoryName, ProductName = p.ProductName, ProductId = p.ProductId, UnitsInStock = p.UnitsInStock };

                return result.ToList();
            }
        }
    }
}
