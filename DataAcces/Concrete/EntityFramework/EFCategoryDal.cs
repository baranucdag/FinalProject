using Business.Abstract;
using Core.DataAccess.EntityFramework;
using Entities.Conscrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAcces.Concrete.EntityFramework
{
    public class EFCategoryDal : EFEntityRepositoryBase<Category, NorthWindContext>, ICategoryDal
    {
        
    }
}
