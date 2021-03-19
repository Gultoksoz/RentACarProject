using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CustomerManager : ICustomerService
    {
        ICustomerDal _customerDal;

        public CustomerManager(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }

        [CacheRemoveAspect("ICustomerService.Get")]
        [ValidationAspect(typeof(CustomerValidator))]
        public IResult Add(Customer entity)
        {
            _customerDal.Add(entity);
            return new SuccessResult(Messages.CustomerAdded);
        }

        [CacheRemoveAspect("ICustomerService.Get")]
        public IResult Delete(Customer entity)
        {
            _customerDal.Delete(entity);
            return new SuccessResult(Messages.CustomerDeleted);
        }

        [CacheAspect]
        public IDataResult<List<Customer>> GetAll()
        {
            return new SuccessDataResult<List<Customer>>(_customerDal.GetAll(), Messages.CustomersListed);
        }

        [CacheAspect]
        public IDataResult<Customer> GetCustomerById(int id)
        {
            return new SuccessDataResult<Customer>(_customerDal.Get(c => c.UserId == id));
        }

        [CacheRemoveAspect("ICustomerService.Get")]
        [ValidationAspect(typeof(CustomerValidator))]
        public IResult Update(Customer entity)
        {
            _customerDal.Update(entity);
            return new SuccessResult(Messages.CustomerAdded);
        }
    }
}
