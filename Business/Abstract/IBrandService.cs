using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IBrandService
    {
        IDataResult<List<Brand>> GetAll();
        IResult Add(Brand brand);
        IResult Delete(string BrandName);
        IResult Update(Brand brand);
        IDataResult<Brand> GetById(int id);
    }
}
