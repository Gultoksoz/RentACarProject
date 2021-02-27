using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new EfCarDal());

            Console.WriteLine("---LIST OF ALL CAR---");
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine( "Car Id : {0}, Car Name: {1}, Brand Number: {2} , Car Color Number: {3} , Car Model Year: {4}, Car Daily Price: {5}" , car.Id ,car.Description , car.BrandId , car.ColorId , car.ModelYear , car.DailyPrice);
            }

            Console.WriteLine("---GetCarsByBrandId---");
            foreach (var car in carManager.GetCarsByBrandId(2))
            {
                Console.WriteLine("Car Id : {0}, Car Name: {1}, Brand Number: {2} , Car Color Number: {3} , Car Model Year: {4}, Car Daily Price: {5}", car.Id, car.Description, car.BrandId, car.ColorId, car.ModelYear, car.DailyPrice);
            }

            Console.WriteLine("---GetCarsByColorId---");
            foreach (var car in carManager.GetCarsByColorId(1))
            {
                Console.WriteLine("Car Id : {0}, Car Name: {1}, Brand Number: {2} , Car Color Number: {3} , Car Model Year: {4}, Car Daily Price: {5}", car.Id, car.Description, car.BrandId, car.ColorId, car.ModelYear, car.DailyPrice);
            }

            carManager.CarControlToAdd(new Car { Id = 7, BrandId = 2, ColorId = 1, DailyPrice = 75000, Description = "My future car", ModelYear = 2035 });

            Console.WriteLine("---NEW CAR WAS ADDED---");
            foreach (var car in carManager.GetAll())
            {   
                Console.WriteLine("Car Name: {0}, Brand Number: {1} , Car Color Number: {2} , Car Model Year: {3}, Car Daily Price: {4}", car.Description, car.BrandId, car.ColorId, car.ModelYear, car.DailyPrice);
            }
        }
    }
}
