using DataAcces.Abstract;
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
    public class EFProductDal : IProductDal
    {
        public void Add(Product entity)
        {
            //IDisposable pattern implentation of c#  (say delete things to the GarbageCollector when block finished )
            using (NorthWindContext context = new NorthWindContext())
            {
                var addedEntity = context.Entry(entity);    //get referance.
                addedEntity.State = EntityState.Added;      //referans will be added. 
                context.SaveChanges();                      //save changes. 

            }
        }

        public void Delete(Product entity)
        {
            using (NorthWindContext context = new NorthWindContext())
            {
                var deletedEntity = context.Entry(entity);    //get referance.
                deletedEntity.State = EntityState.Deleted;      //referans will be deleted. 
                context.SaveChanges();                        //save changes. 

            }
        }

        public Product Get(Expression<Func<Product, bool>> filter)  //that will return a single data
        {
            using (NorthWindContext context = new NorthWindContext())
            {
                return context.Set<Product>().SingleOrDefault(filter);
            }
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            using (NorthWindContext context = new NorthWindContext())
            {
                return filter == null ? context.Set<Product>().ToList():context.Set<Product>().Where(filter).ToList();
            }               //if filter is null return all info, else return info according to filter
        }

        public void Uptade(Product entity)
        {
            using (NorthWindContext context = new NorthWindContext())
            {
                var uptadedEntity = context.Entry(entity);
                uptadedEntity.State = EntityState.Modified;
                context.SaveChanges();

            }
        }
    }
}
