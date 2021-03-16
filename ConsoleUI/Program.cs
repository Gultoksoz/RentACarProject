using Business.Concrete;
using Core.Entities.Concrete;
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
           // CarTest();
            //BrandTest();

            //ColorTest();

           // RentACarTest();
        }

        private static void RentACarTest()
        {
            UserManager userManager = new UserManager(new EfUserDal());
            var resultUser = userManager.Add(new User() { Id = 11, FirstName = "Mary", LastName = "Bowny", Email = "mary_bowny" });
            if (resultUser.Success == true)
            {
                Console.WriteLine(resultUser.Message);
            }
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            var resultCustomer = customerManager.Add(new Customer() { Id=11 ,UserId = 8, CompanyName = "Unknown Company2" });
            if (resultCustomer.Success == true)
            {
                Console.WriteLine(resultCustomer.Message);
            }

            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            var resultRentCar = rentalManager.Add(new Rental() { Id =8, CarId = 2, CustomerId = 1, RentDate = new DateTime(2020,10,01), ReturnDate = new DateTime(2020,11,27) });

            if (resultRentCar.Success == true)
            {
                Console.WriteLine(resultRentCar.Message);
            }

        }

        private static void ColorTest()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            Color color1 = new Color() { Id = 5, Name = "Pink" };

            Console.WriteLine("\n---ADDED A COLOR---");
            colorManager.Add(color1);

            Console.WriteLine("\n---LIST OF ALL COLOR---");
            var result = colorManager.GetAll();
            if(result.Success==true)
            {
                foreach (var brand in result.Data)
                {
                    Console.WriteLine("{0}  ", brand.Id, brand.Name);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }

            var resultUpdate = colorManager.Update(color1);
            if (resultUpdate.Success==true)
            {
                Console.WriteLine("\n" , resultUpdate.Message);
            }
            else
            {
                Console.WriteLine("color not updated");
            }

            Console.WriteLine("\n---GET COLOR BY ID---");
            Console.WriteLine(colorManager.GetColorById(5).Data.Name);

          
            var resultDelete = colorManager.Delete(color1);

            if (resultDelete.Success == true)
            {
                Console.WriteLine(resultDelete.Message);
            }
            else
            {
                Console.WriteLine("color not deleted");
            }
        }

        private static void BrandTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            Brand brand1 = new Brand() { Id = 5, Name = "FIAT" };

            Console.WriteLine("\n---ADDED A BRAND---");
            brandManager.Add(brand1);

            Console.WriteLine("\n---LIST OF ALL BRAND---");
            var resultBrand = brandManager.GetAll();
            if(resultBrand.Success==true)
            {
                foreach (var brand in resultBrand.Data)
                {
                    Console.WriteLine("{0}  ", brand.Id, brand.Name);
                }
            }
            else
            {
                Console.WriteLine(resultBrand.Message);
            }
           
            Console.WriteLine("\n---UPDATED BRAND---");
            brandManager.Update(brand1);

            Console.WriteLine("\n---GET BRAND BY ID---");
            Console.WriteLine(brandManager.GetBrandById(5).Data.Name);

            Console.WriteLine("\n---DELETED BRAND---");
            brandManager.Delete(brand1);
        }

        private static void CarTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());

            Car car1 = new Car() { Id = 8, BrandId = 3, ColorId = 1, DailyPrice = 20000, Description = "VosVos", ModelYear = 2015 };
            carManager.Update(car1);


            var resultCar = carManager.GetAll();
            if(resultCar.Success==true)
            {
                Console.WriteLine("\n", resultCar.Message);
                foreach (var car in resultCar.Data)
                {
                    Console.WriteLine("Car Id : {0}, Car Name: {1}, Brand Number: {2} , Car Color Number: {3} , Car Model Year: {4}, Car Daily Price: {5}", car.Id, car.Description, car.BrandId, car.ColorId, car.ModelYear, car.DailyPrice);
                }
            }
            else
            {
                Console.WriteLine(resultCar.Message);
            }



            var resultCarBrandId = carManager.GetCarsByBrandId(2);
            if (resultCarBrandId.Success == true)
            {
                Console.WriteLine("\n", resultCarBrandId.Message);
                foreach (var car in resultCarBrandId.Data)
                {
                    Console.WriteLine("Car Id : {0}, Car Name: {1}, Brand Number: {2} , Car Color Number: {3} , Car Model Year: {4}, Car Daily Price: {5}", car.Id, car.Description, car.BrandId, car.ColorId, car.ModelYear, car.DailyPrice);
                }
            }



            var resultCarColorId = carManager.GetCarsByColorId(1);
            if (resultCarColorId.Success == true)
            {
                Console.WriteLine("\n", resultCarColorId.Message);
                foreach (var car in resultCarColorId.Data)
                {
                    Console.WriteLine("Car Id : {0}, Car Name: {1}, Brand Number: {2} , Car Color Number: {3} , Car Model Year: {4}, Car Daily Price: {5}", car.Id, car.Description, car.BrandId, car.ColorId, car.ModelYear, car.DailyPrice);
                }
            }


            var resultNewCar = carManager.Add(new Car { Id = 5, BrandId = 2, ColorId = 1, DailyPrice = 75000, Description = "My future car", ModelYear = 2035 });
            if (resultNewCar.Success == true)
            {
                Console.WriteLine(resultNewCar.Message);
            }
            else
            {
                Console.WriteLine(resultNewCar.Message);
            }


            var deleted = carManager.Delete(car1);
            Console.WriteLine("\n", deleted.Message);


            var resultCarDetails = carManager.GetCarDetails();
            if (resultCarDetails.Success == true)
            {
                Console.WriteLine("\n", resultCarDetails.Message);
                foreach (var car in resultCarDetails.Data)
                {
                    Console.WriteLine(car.CarName + " -- " + car.BrandName + " -- " + car.ColorName + " -- " + car.DailyPrice);
                }
            }



        }
    }
}
