using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class BrandManager : IBrandService
    {
        IBrandDal _brandDal;

        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }

        [CacheRemoveAspect("IBrandService.Get")]
        [SecuredOperation("brand.add,admin")]
        [ValidationAspect(typeof(BrandValidator))]
        public IResult Add(Brand entity)
        {
            IResult result = BusinessRules.Run(CheckIfBrandNameExists(entity.Name));
            if(result!=null)
            {
                return result;
            }

            _brandDal.Add(entity);
            return new SuccessResult(Messages.BrandAdded);
        }

        [CacheRemoveAspect("IBrandService.Get")]
        [SecuredOperation("brand.delete,admin")]
        public IResult Delete(Brand entity)
        {
            _brandDal.Delete(entity);
            return new SuccessResult(Messages.BrandDeleted);
        }

        [CacheAspect]
        public IDataResult<List<Brand>> GetAll()
        {
           /* if (DateTime.Now.Hour == 22)
            {
                return new ErrorDataResult<List<Brand>>(Messages.MaintenanceTime);
            }*/

            return new SuccessDataResult<List<Brand>>(_brandDal.GetAll(), Messages.BrandsListed);
        }

        [CacheAspect]
        public IDataResult<Brand> GetBrandById(int id)
        {
            return new SuccessDataResult<Brand>( _brandDal.Get(c=>c.Id==id));
        }


        [CacheRemoveAspect("IBrandService.Get")]
        [SecuredOperation("brand.update,admin")]
        [ValidationAspect(typeof(BrandValidator))]
        public IResult Update(Brand entity)
        {
            _brandDal.Update(entity);
            return new SuccessResult(Messages.BrandUpdated);
        }


        private IResult CheckIfBrandNameExists(string name)
        {
            var result = _brandDal.GetAll(b => b.Name == name).Any();
            if(result)
            {
                return  new ErrorResult(Messages.BrandNameAlreadyExists);
            }
            return new SuccessResult();
        }
    }
}
