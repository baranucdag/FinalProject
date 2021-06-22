﻿using Core.DataAccess.EntityFramework;
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
    public class EFProductDal :EFEntityRepositoryBase<Product,NorthWindContext> ,IProductDal
    {
    }
}
