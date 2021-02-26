using Business.Concrete;
using DataAccess.Concrete.InMemory;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new InMemoryCarDal());
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine( "Car Name: {0}, Brand Number: {1} , Car Color Number: {2} , Car Model Year: {3}, Car Daily Price: {4}" , car.Description , car.BrandId , car.ColorId , car.ModelYear , car.DailyPrice);
            }
            
        }
    }
}
