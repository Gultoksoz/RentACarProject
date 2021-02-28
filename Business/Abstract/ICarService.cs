using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarService
    {
        List<Car> GetAll();
        List<Car> GetCarsByBrandId(int id);
        List<Car> GetCarsByColorId(int id);
        void CarControlToAdd(Car entity);
        List<CarDetailDto> GetCarDetails();
        void Delete(Car entity);
        void Update(Car entity);
    }
}
