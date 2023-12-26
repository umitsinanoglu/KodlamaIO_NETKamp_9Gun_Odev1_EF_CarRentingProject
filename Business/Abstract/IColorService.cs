using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IColorService
    {
        IDataResult<List<Color>> GetAll();
        IResult Add(Color color);
        IResult Delete(string ColorName);
        IResult Update(Color color);
        IDataResult<Color> GetById(int id);
    }
}
