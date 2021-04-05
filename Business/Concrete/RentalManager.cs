using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;

        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }

        [CacheRemoveAspect("IRentalService.Get")]
        [SecuredOperation("rental.add,admin")]
        [ValidationAspect(typeof(RentalValidator))]
        public IResult Add(Rental entity)
        {
            RentalDetailDto _rentalDetailDto;
            _rentalDetailDto = _rentalDal.GetRentalDetailByCarId(entity.CarId);
            if (_rentalDetailDto==null)
            {
                _rentalDal.Add(entity);
                return new SuccessResult(Messages.RentalAdded);

            }
            else if (_rentalDetailDto.ReturnDate.Year < 2021)
            {
                _rentalDal.Add(entity);
                return new SuccessResult(Messages.RentalAdded);
            }
            else
            {
                return new ErrorResult(Messages.RentalNotAdded);
            }
             
        }

        [CacheRemoveAspect("IRentalService.Get")]
        [SecuredOperation("rental.delete,admin")]
        public IResult Delete(Rental entity)
        {
            _rentalDal.Delete(entity);
            return new SuccessResult(Messages.RentalDeleted);
        }

        [CacheAspect]
        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(), Messages.RentalsListed);
        }

        [CacheAspect]
        public IDataResult<Rental> GetRentalById(int id)
        {
            return new SuccessDataResult<Rental>(_rentalDal.Get(c => c.Id == id));
        }

        public IDataResult<RentalDetailDto> GetRentalDetailByCarId(int id)
        {
            return new SuccessDataResult<RentalDetailDto>(_rentalDal.GetRentalDetailByCarId(id));
        }

        public IDataResult<List<RentalDetailDto>> GetRentalDetails()
        {
            return new SuccessDataResult<List<RentalDetailDto>>(_rentalDal.GetRentalDetails());
        }

        [CacheAspect]
        public IDataResult<List<Rental>> GetRentalsByCarId(int id)
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(c => c.CarId == id), Messages.RentalsListed);
        }

        
        public IDataResult<List<Rental>> GetRentalsByCustomerId(int id)
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(c => c.CustomerId == id), Messages.RentalsListed);
        }

        [CacheRemoveAspect("IRentalService.Get")]
        [SecuredOperation("rental.update,admin")]
        [ValidationAspect(typeof(RentalValidator))]
        public IResult Update(Rental entity)
        {
            _rentalDal.Update(entity);
            return new SuccessResult(Messages.RentalUpdated);
        }
    }
}
