using Core.Entities.Concrete;
using Entities.Concrete;
using Entities.Conscrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcces.Concrete.EntityFramework
{
    //context: Db tabloları ile proje classlarını bağlamakk
    public class NorthWindContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=Northwind;Trusted_Connection=true");  //Domain'e hizmet eden class'lar ile Db'nin bağlanması
        }                                       //server adresi                 //db ismi           //db parolası

        public DbSet<Product> Products { get; set; }            //Karşılıklı eşleştirme (hangi nesne, hangi tablo)
        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }
    }
}
