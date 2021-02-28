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
            CarTest();
            //BrandTest();

           //ColorTest();

        }

        private static void ColorTest()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            Color color1 = new Color() { Id = 5, Name = "Pink" };

            Console.WriteLine("\n---ADDED A COLOR---");
            colorManager.Add(color1);

            Console.WriteLine("\n---LIST OF ALL COLOR---");
            foreach (var brand in colorManager.GetAll())
            {
                Console.WriteLine("{0}  ", brand.Id, brand.Name);
            }
            Console.WriteLine("\n---UPDATED COLOR---");
            colorManager.Update(color1);

            Console.WriteLine("\n---GET COLOR BY ID---");
            Console.WriteLine(colorManager.GetById(5).Name);

            Console.WriteLine("\n---DELETED COLOR---");
            colorManager.Delete(color1);
        }

        private static void BrandTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            Brand brand1 = new Brand() { Id = 5, Name = "FIAT" };

            Console.WriteLine("\n---ADDED A BRAND---");
            brandManager.Add(brand1);

            Console.WriteLine("\n---LIST OF ALL BRAND---");
            foreach (var brand in brandManager.GetAll())
            {
                Console.WriteLine("{0}  ", brand.Id, brand.Name);
            }
            Console.WriteLine("\n---UPDATED BRAND---");
            brandManager.Update(brand1);

            Console.WriteLine("\n---GET BRAND BY ID---");
            Console.WriteLine(brandManager.GetById(5).Name);

            Console.WriteLine("\n---DELETED BRAND---");
            brandManager.Delete(brand1);
        }

        private static void CarTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());

            Car car1 = new Car() { Id = 1, BrandId = 3, ColorId = 1, DailyPrice = 20000, Description = "VosVos", ModelYear = 2015 };
            carManager.Update(car1);

            Console.WriteLine("---LIST OF ALL CAR---");
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine("Car Id : {0}, Car Name: {1}, Brand Number: {2} , Car Color Number: {3} , Car Model Year: {4}, Car Daily Price: {5}", car.Id, car.Description, car.BrandId, car.ColorId, car.ModelYear, car.DailyPrice);
            }

            Console.WriteLine("\n---GetCarsByBrandId---");
            foreach (var car in carManager.GetCarsByBrandId(2))
            {
                Console.WriteLine("Car Id : {0}, Car Name: {1}, Brand Number: {2} , Car Color Number: {3} , Car Model Year: {4}, Car Daily Price: {5}", car.Id, car.Description, car.BrandId, car.ColorId, car.ModelYear, car.DailyPrice);
            }

            Console.WriteLine("\n---GetCarsByColorId---");
            foreach (var car in carManager.GetCarsByColorId(1))
            {
                Console.WriteLine("Car Id : {0}, Car Name: {1}, Brand Number: {2} , Car Color Number: {3} , Car Model Year: {4}, Car Daily Price: {5}", car.Id, car.Description, car.BrandId, car.ColorId, car.ModelYear, car.DailyPrice);
            }

            carManager.CarControlToAdd(new Car { Id = 5, BrandId = 2, ColorId = 1, DailyPrice = 75000, Description = "My future car", ModelYear = 2035 });

            Console.WriteLine("\n---NEW CAR WAS ADDED---");
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine("Car Name: {0}, Brand Number: {1} , Car Color Number: {2} , Car Model Year: {3}, Car Daily Price: {4}", car.Description, car.BrandId, car.ColorId, car.ModelYear, car.DailyPrice);
            }
            Console.WriteLine("\n---CAR WAS DELETED---");
            carManager.Delete(car1);

            Console.WriteLine("\n---GET CARS WİTH BRAND AND COLOR NAME---");
            foreach (var car in carManager.GetCarDetails())
            {
                Console.WriteLine(car.CarName + " -- " + car.BrandName + " -- " + car.ColorName + " -- " + car.DailyPrice);
            }
           
        }
    }
}
