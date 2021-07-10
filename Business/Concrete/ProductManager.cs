using Business.Abstract;
using Business.CCS;
using Business.Constans;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Results;
using DataAcces.Abstract;
using Entities.Concrete;
using Entities.Conscrete;
using FluentValidation;
using System;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        IProductDal _productDal;
        ILogger _logger;

        public ProductManager(IProductDal productDal,ILogger logger)
        {
            _productDal = productDal;
            _logger = logger;
        }

        //[ValidationAspect(typeof(ProductValidator))]       //validate add methods according to ProductValidator. 
        public IResult Add(Product product)
        {
            _logger.Log();
            try
            {
                _productDal.Add(product);
                return new Result(true, Messages.ProductAdded);
            }
            catch (Exception exception)
            {
                _logger.Log();
            }
            return new ErrorResult();

        }

        public IDataResult<List<Product>> GetAll()
        {
            if (DateTime.Now.Hour == 11)
            {
                return new ErrorDataResult<List<Product>>(Messages.MaintenanceTime);
            }
            return new SuccesDataResult<List<Product>>(_productDal.GetAll(),Messages.ProductListed);    
        }

        public IDataResult<List<Product>> GetAllByCategoryId(int id)
        {
            return new SuccesDataResult<List<Product>>(_productDal.GetAll(p => p.CategoryId == id));

        }
        public IDataResult<Product> GetById(int productId)
        {
            return new SuccesDataResult<Product>(_productDal.Get(p=>p.ProductId==productId));
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
    }
}
