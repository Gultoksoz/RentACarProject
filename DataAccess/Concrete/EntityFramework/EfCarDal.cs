using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, RentACarContext>, ICarDal
    {
        public List<CarDetailDto> GetCarsDetails()
        {
            using (RentACarContext context= new RentACarContext())
            {
                var result = from car in context.Cars
                             join b in context.Brands on car.BrandId equals b.Id
                             join color in context.Colors on car.ColorId equals color.Id
                             select new CarDetailDto {CarId= car.Id, CarName=car.Description, BrandName= b.Name, ColorName=color.Name, DailyPrice=car.DailyPrice , ModelYear= car.ModelYear}
                             ;

                return result.ToList();
            }
        }

        public List<CarDetailDto> GetCarDetails(Expression<Func<CarDetailDto, bool>> filter = null)
        {
            using (RentACarContext context = new RentACarContext())
            {
                var result = from car in context.Cars
                             join brand in context.Brands
                             on car.BrandId equals brand.Id
                             join color in context.Colors
                             on car.ColorId equals color.Id

                             select new CarDetailDto()
                             {
                                 CarId = car.Id,
                                 CarName = car.Description,
                                 BrandName = brand.Name,
                                 ColorName = color.Name,
                                 DailyPrice = car.DailyPrice,
                                 ModelYear = car.ModelYear,

                             };

                return filter == null ? result.ToList() : result.Where(filter).ToList();
            }
        }
    }
}
