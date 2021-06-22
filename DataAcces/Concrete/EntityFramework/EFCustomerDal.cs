using Business.Abstract;
using Core.DataAccess.EntityFramework;
using DataAcces.Abstract;
using Entities.Concrete;
using Entities.Conscrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAcces.Concrete.EntityFramework
{
    public class EFCustomerDal : EFEntityRepositoryBase<Customer, NorthWindContext>, ICustomerDal
    {
    }
}
