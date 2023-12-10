using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;

        public CarManager(ICarDal cardal)
        {
            _carDal = cardal;
        }

        public IResult Add(Car car)
        {
            if (car.ModelName.Length < 3)
            {
                return new ErrorResult(Messages.CarNameInvalid);
            }
            _carDal.Add(car);
            return new SuccessResult(Messages.CarAdded);
        }
        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult(Messages.CarDeleted);
        }
        public IResult Update(Car car)
        {
            _carDal.Update(car);
            return new SuccessResult(Messages.CarUpdated);
        }

        public IDataResult<List<Car>> GetAll()
        {
            if (DateTime.Now.Hour == 21)
            {
                return new ErrorDataResult<List<Car>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(), Messages.CarsListed);
        }

        public IDataResult<List<Car>> GetAllByDailyPriceRange(decimal min, decimal max)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.DailyPrice >= min && c.DailyPrice <= max), Messages.CarsListed);
        }

        public IDataResult<Car> GetById(int id)
        {
            return new SuccessDataResult<Car>(_carDal.Get(c => c.Id == id), Messages.CarListed);
        }

        public IDataResult<List<Car>> GetCarsByBrandId(int brandId)
        {
            var result = new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.BrandId == brandId).ToList());

            if (!result.IsSuccess)
            {
                return new ErrorDataResult<List<Car>>(Messages.BrandIdInvalid);
            }
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.BrandId == brandId).ToList(), Messages.CarsListed);
        }

        public IDataResult<List<Car>> GetCarsByColorId(int colorId)
        {
            var result = new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.ColorId == colorId).ToList());

            if (!result.IsSuccess)
            {
                return new ErrorDataResult<List<Car>>(Messages.ColorIdInvalid);
            }
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.ColorId == colorId).ToList(), Messages.CarsListed);
        }


        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails(), Messages.CarsListed);
        }

        public IResult DeleteById(int id)
        {
            var carToDeleteDataResult = new SuccessDataResult<Car>(_carDal.Get(c => c.Id == id));

            if (carToDeleteDataResult.IsSuccess)
            {
                Car carToDelete = carToDeleteDataResult.Data;
                _carDal.Delete(carToDelete);
                return new SuccessResult(Messages.CarDeleted);
            }
            else
            {
                return new ErrorResult(Messages.CarIdInvalid);
            }
        }
    }
}
