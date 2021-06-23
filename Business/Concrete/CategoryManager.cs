using Business.Abstract;
using Entities.Conscrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{                                               //write business code if you have.
    public class CategoryManager : ICategoryService
    {
        ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public List<Category> GetAll()
        {
            return _categoryDal.GetAll();
        }

        public Category GetById(int categoryId)
        {
            return _categoryDal.Get(c=>c.CategoryId==categoryId);       //Select*from Categories where categoryId=3
        }
    }
}
