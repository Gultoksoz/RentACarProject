using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICustomerService
    {
        IDataResult<List<Customer>> GetAll();
        IDataResult<Customer> GetCustomerById(int id);
        IResult Add(Customer entity);
        IResult Delete(Customer entity);
        IResult Update(Customer entity);
    }
}
