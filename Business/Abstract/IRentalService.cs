using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IRentalService
    {
        IDataResult<List<Rental>> GetAll();
        IResult Add(Rental rental);
        IResult Delete(int RentalId);
        IResult Update(Rental rental);
        IDataResult<Rental> GetById(int id);
    }
}
