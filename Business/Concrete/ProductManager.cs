using Business.Abstract;
using Business.BusinessAspect.Autofac;
using Business.CCS;
using Business.Constans;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Aspects.Caching;
using Core.Aspects.Performance;
using Core.Aspects.Transaction;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAcces.Abstract;
using Entities.Concrete;
using Entities.Conscrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        IProductDal _productDal;
        ICategoryService _categoryService;

        public ProductManager(IProductDal productDal, ICategoryService categoryService)
        {
            _productDal = productDal;
            _categoryService = categoryService;
        }

        //[SecuredOperation("product.add,admin")]
        [ValidationAspect(typeof(ProductValidator))]       //validate add methods according to ProductValidator. 
        [CacheRemoveAspect("IProductService.Get")]
        public IResult Add(Product product)
        {
            //business field

            IResult result = BusinessRules.Run(CheckIfProductCountOfCagetoryCorrect(product.CategoryId),
                CheckIfProductNameExist(product.ProductName), CheckIfCatageoryLimitExceted());
            if (result != null)
            {
                return result;
            }

            _productDal.Add(product);

            return new SuccesResult(Messages.ProductAdded);

        }

        [CacheAspect]
        public IDataResult<List<Product>> GetAll()
        {
            if (DateTime.Now.Hour == 15)
            {
                return new ErrorDataResult<List<Product>>(Messages.MaintenanceTime);
            }
            return new SuccesDataResult<List<Product>>(_productDal.GetAll(), Messages.ProductListed);
        }

        public IDataResult<List<Product>> GetAllByCategoryId(int id)
        {
            return new SuccesDataResult<List<Product>>(_productDal.GetAll(p => p.CategoryId == id));
        }

        [CacheAspect]
        [PerformanceAspect(5)]
        public IDataResult<Product> GetById(int productId)
        {
            return new SuccesDataResult<Product>(_productDal.Get(p => p.ProductId == productId));
        }


        public IDataResult<List<Product>> GetByUnitPrice(decimal min, decimal max)
        {
            return new SuccesDataResult<List<Product>>(_productDal.GetAll(p => p.UnitPrice >= min && p.UnitPrice <= max));
        }

        public IDataResult<List<ProductDetailDto>> GetProductDetails()
        {
            return new SuccesDataResult<List<ProductDetailDto>>(_productDal.GetProductDetails());
        }

        [ValidationAspect(typeof(ProductValidator))]
        [CacheRemoveAspect("IProductService.Get")]
        public IResult Uptade(Product product)
        {
            _productDal.Uptade(product);
            return new SuccesResult(Messages.ProductUpdated);
        }
        public IResult Delete(Product product)
        {
             _productDal.Delete(product);
            return new SuccesResult(Messages.ProductDeleted);
        }

        private IResult CheckIfProductCountOfCagetoryCorrect(int categoryId)
        {
            //Select count(*) from products where categoryId=1
            var result = _productDal.GetAll(p => p.CategoryId == categoryId).Count;
            if (result >= 15)
            {
                return new ErrorResult(Messages.ProductAmountOfCategoryError);
            }
            return new SuccesResult();
        }

        private IResult CheckIfProductNameExist(string productName)
        {
            var result = _productDal.GetAll(p => p.ProductName == productName).Any();
            if (result)
            {
                return new ErrorResult(Messages.ProductNameExist);
            }
            return new SuccesResult();
        }

        private IResult CheckIfCatageoryLimitExceted()
        {
            var result = _categoryService.GetAll();
            if (result.Data.Count>15)
            {
                return new ErrorResult();
            }
            return new SuccesResult(Messages.CategoryLimitExceted);
        }

        [TransactionScopeAspect]
        public IResult AddTransactionTest(Product product)
        {
            Add(product);
            if (product.UnitPrice < 10)
            {
                throw new Exception("");
            }

            Add(product);

            return null;
        }
    }
}
