using Business.Abstract;
using Business.CCS;
using Business.Constans;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
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

        [ValidationAspect(typeof(ProductValidator))]       //validate add methods according to ProductValidator. 
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


        public IDataResult<List<Product>> GetAll()
        {
            if (DateTime.Now.Hour == 11)
            {
                return new ErrorDataResult<List<Product>>(Messages.MaintenanceTime);
            }
            return new SuccesDataResult<List<Product>>(_productDal.GetAll(), Messages.ProductListed);
        }

        public IDataResult<List<Product>> GetAllByCategoryId(int id)
        {
            return new SuccesDataResult<List<Product>>(_productDal.GetAll(p => p.CategoryId == id));

        }
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

        public void Uptade(Product product)
        {
            _productDal.Uptade(product);
        }
        public void Delete(Product product)
        {
            _productDal.Delete(product);
        }

        private IResult CheckIfProductCountOfCagetoryCorrect(int categoryId)
        {
            var result = _productDal.GetAll(p => p.CategoryId == categoryId).Count;
            if (result >= 10)
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
            if (result.Data.Count>=15)
            {
                return new SuccesResult(Messages.CategoryLimitExceted);
            }
            return new ErrorResult();
        }
    }
}
