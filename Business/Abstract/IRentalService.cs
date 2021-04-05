using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IRentalService
    {
        IDataResult<List<Rental>> GetAll();
        IDataResult<Rental> GetRentalById(int id);
        IDataResult<List<Rental>> GetRentalsByCarId(int id);
        IDataResult<List<Rental>> GetRentalsByCustomerId(int id);
        IDataResult<RentalDetailDto> GetRentalDetailByCarId(int id);
        IDataResult<List<RentalDetailDto>> GetRentalDetails();
        IResult Add(Rental entity);
        IResult Delete(Rental entity);
        IResult Update(Rental entity);
    }
}

