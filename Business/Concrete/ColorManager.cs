using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class ColorManager : IColorService
    {
        IColorDal _colorDal;

        public ColorManager(IColorDal colorDal)
        {
            _colorDal = colorDal;
        }

        [ValidationAspect(typeof(ColorValidator))]
        public IResult Add(Color entity)
        { 
            _colorDal.Add(entity);
            return new SuccessResult(Messages.ColorAdded);
        }

        public IResult Delete(Color entity)
        {
            _colorDal.Delete(entity);

            return new SuccessResult(Messages.ColorDeleted);

        }

        public IDataResult<Color> GetColorById(int id)
        {
            return new SuccessDataResult<Color>( _colorDal.Get(c => c.Id == id));
        }

        public IDataResult<List<Color>> GetAll()
        {
            if (DateTime.Now.Hour==22)
            {
                return new ErrorDataResult<List<Color>>(Messages.MaintenanceTime);
            }

            return  new SuccessDataResult<List<Color>>( _colorDal.GetAll(), Messages.ColorsListed);
        }

        public IResult Update(Color entity)
        {
            _colorDal.Update(entity);

           return new SuccessResult(Messages.ColorUpdated);
        }
    }
}
