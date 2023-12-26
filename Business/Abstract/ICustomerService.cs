using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface ICustomerService
    {
        IDataResult<List<Customer>> GetAll();
        IResult Add(Customer customer);
        IResult Delete(int CustomerId);
        IResult Update(Customer customer);
        IDataResult<Customer> GetById(int id);
    }
}
