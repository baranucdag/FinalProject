using Business.Abstract;
using DataAcces.Abstract;
using Entities.Conscrete;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public List<Product> GetAll()
        {   //bir iş sınıfı başka sınıfları new'lemez
            //İş kodları
            return _productDal.GetAll();    //burada filtreleme yapmak adına daha öncesinde IEntityRepostory interfac'ıne fonksiyonel işlev eklemiştik
                                            //p=>p.PateboryId=2 yazabiliriz parantez içerisine
        }
    }
}
