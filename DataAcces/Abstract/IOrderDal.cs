﻿using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcces.Abstract
{
    public interface IOrderDal:IEntityRepository<Order>
    {
    }
}
