using Core.Entites;
using DataAcces.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess.EntityFramework
{
    public class EFEntityRepositoryBase<TEntity, TContext> : IEntityRepository<TEntity>   //we need 2 type first one is table typr(product, customer), secons one is context type (Npethwind)
        where TEntity : class, IEntity, new()                //table of database        //TEntity rules (cannot contain IEntity)
        where TContext : DbContext, new()
    {
        public void Add(TEntity entity)
        {
            //IDisposable pattern implentation of c#  (say delete things to the GarbageCollector when block finished )
            using (TContext context = new TContext())
            {
                var addedEntity = context.Entry(entity);    //get referance.
                addedEntity.State = EntityState.Added;      //referans will be added. 
                context.SaveChanges();                      //save changes. 

            }
        }

        public void Delete(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var deletedEntity = context.Entry(entity);    //get referance.
                deletedEntity.State = EntityState.Deleted;      //referans will be deleted. 
                context.SaveChanges();                        //save changes. 

            }
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)  //that will return a single data
        {
            using (TContext context = new TContext())
            {
                return context.Set<TEntity>().SingleOrDefault(filter);
            }
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            using (TContext context = new TContext())
            {
                return filter == null ? context.Set<TEntity>().ToList() : context.Set<TEntity>().Where(filter).ToList();
            }               //if filter is null return all info, else return info according to filter
        }

        public void Uptade(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var uptadedEntity = context.Entry(entity);
                uptadedEntity.State = EntityState.Modified;
                context.SaveChanges();

            }
        }
    }
}
