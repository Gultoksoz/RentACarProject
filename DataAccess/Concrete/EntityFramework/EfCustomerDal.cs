using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCustomerDal : EfEntityRepositoryBase<Customer, RentACarContext>, ICustomerDal
    {
        public List<CustomerDetailDto> GetCustomersDetails()
        {
            using (RentACarContext context = new RentACarContext())
            {
                var result =
                    from customer in context.Customers
                    join user in context.Users on customer.UserId equals user.Id
                    select new CustomerDetailDto
                    {
                        Id = customer.Id,
                        UserId = user.Id,
                        FirstName = user.FirstName,
                        LastName = user.LastName,
                        Email = user.Email,
                        CompanyName = customer.CompanyName
                    };
                return result.ToList();
            }
        }
    }
}
