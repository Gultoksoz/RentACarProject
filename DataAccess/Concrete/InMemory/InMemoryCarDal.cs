using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _car;

        public InMemoryCarDal()
        {
            _car = new List<Car> { 
            new Car {Id=1, BrandId= 1, ColorId= 542, DailyPrice= 22500, Description="Ford Focus", ModelYear=2000},
            new Car {Id=2, BrandId= 1, ColorId= 142, DailyPrice= 12500, Description="Mercedes-Benz", ModelYear=1998},
            new Car {Id=3, BrandId= 2, ColorId= 532, DailyPrice= 32500, Description="Volkswagen", ModelYear=2000},
            new Car {Id=4, BrandId= 3, ColorId= 902, DailyPrice= 9500, Description="Porsche", ModelYear=2010},
            new Car {Id=5, BrandId= 2, ColorId= 765, DailyPrice= 8500, Description="BMW", ModelYear=2018}
            };
        }

        public void Add(Car car)
        {
            _car.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = _car.SingleOrDefault(c=>c.Id == car.Id);
            _car.Remove(carToDelete);
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            return _car;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetById(int Id)
        {
            return _car.Where(c=>c.Id == Id).ToList();
        }

        public void Update(Car car)
        {
            Car carToUpdate = _car.SingleOrDefault(c => c.Id == car.Id);
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
        }
    }
}
