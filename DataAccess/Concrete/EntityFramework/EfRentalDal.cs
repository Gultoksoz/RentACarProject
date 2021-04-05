using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal: EfEntityRepositoryBase<Rental, RentACarContext>, IRentalDal
    {
        public RentalDetailDto GetRentalDetailByCarId(int id)
        {
            using (RentACarContext context = new RentACarContext())
            {
                var result = (from r in context.Rentals
                              join c in context.Cars on r.CarId equals c.Id
                              join cm in context.Customers on r.CustomerId equals cm.Id
                              join u in context.Users on cm.Id equals u.Id
                              join cd in context.Brands on c.BrandId equals cd.Id
                              where r.CarId == id
                              orderby r.Id
                              select new RentalDetailDto { Id = r.Id, CarId = c.Id, CarName=(cd.Name + c.Description), CustomerName = (u.FirstName + u.LastName), RentDate = r.RentDate, ReturnDate = r.ReturnDate }).LastOrDefault();



                return result;
            }
        }

        public List<RentalDetailDto> GetRentalDetails()
        {
            using (RentACarContext context = new RentACarContext())
            {
                var result = from r in context.Rentals
                             join c in context.Cars on r.CarId equals c.Id
                             join cm in context.Customers on r.CustomerId equals cm.Id
                             join u in context.Users on cm.Id equals u.Id
                             join cd in context.Brands on c.BrandId equals cd.Id
                             select new RentalDetailDto { Id = r.Id, CarId = c.Id, CarName = (cd.Name + c.Description), CustomerName = (u.FirstName + u.LastName), RentDate = r.RentDate, ReturnDate = r.ReturnDate }
                             ;

                return result.ToList();
            }
        }

    }
}
