using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;

namespace ConsoleUi
{
    public class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new EfCarDal()); // Örnek oluşturulduğunu varsayalım

            Random random = new Random();

            // Rastgele car değerler oluşturma
            int randomId = random.Next(1, 1000); // 1 ile 100 arasında rastgele bir Id
            int randomBrandId = random.Next(1, 10); // 1 ile 10 arasında rastgele bir BrandId
            int randomColorId = random.Next(1, 10); // 1 ile 10 arasında rastgele bir ColorId
            decimal randomDailyPrice = (decimal)(random.NextDouble() * (1000000 - 50000) + 50000); // 50,000 ile 1,000,000 arasında rastgele bir DailyPrice
            int randomModelYear = random.Next(DateTime.Now.Year, DateTime.Now.Year + 5); // Şu anki yıldan başlayarak 5 yıl ileriye kadar rastgele bir ModelYear
            string[] carNames = { "Renault Clio", "Ford Focus", "Toyota Corolla", "BMW 3 Series", "Mercedes-Benz C-Class" };
            string randomName = carNames[random.Next(0, carNames.Length)]; // Örnek araba isimlerinden rastgele bir Name

            // Oluşturulan rastgele değerlerle Car nesnesini oluşturma ve ekleme
            carManager.Add(new Car()
            {
                Id = randomId,
                BrandId = randomBrandId,
                ColorId = randomColorId,
                ModelName = $"{randomName} {randomId}",
                DailyPrice = randomDailyPrice,
                Description = "Rastgele Açıklama",
                ModelYear = randomModelYear
            });
            var result = carManager.GetAll();
            if (result.IsSuccess == true)
            {
                foreach (var car in result.Data)
                {
                    Console.WriteLine(car.Id + " - " + car.ModelName);
                }
            }
            Console.WriteLine("*******************************************1");
            var result1 = carManager.GetById(randomId);
            Console.WriteLine(result1.Data.ModelName);

            Console.WriteLine("*******************************************2");

            Console.WriteLine("*******************************************3");
            var result2 = carManager.GetAllByDailyPriceRange(9000, 990000);
            if (result2.IsSuccess == true)
            {
                foreach (var car in result.Data)
                {
                    Console.WriteLine(car.Id + " - " + car.ModelName + " - " + car.DailyPrice);
                }
            }
            Console.WriteLine("*******************************************4");

            BrandManager brandManager = new BrandManager(new EfBrandDal());
            var result3 = carManager.GetCarsByBrandId(randomBrandId);
            if (result.IsSuccess == true)
            {
                foreach (var car in result3.Data)
                {
                    Console.WriteLine(car.Id + " - " + car.ModelName + " - " + brandManager.GetById(car.BrandId).name);
                }
            }

            Console.WriteLine("*******************************************5");
            ColorManager colorManager = new ColorManager(new EfColorDal());
            var result4 = carManager.GetCarsByColorId(randomColorId);
            if (result.IsSuccess == true)
            {
                foreach (var car in result4.Data)
                {
                    Console.WriteLine(car.Id + " - " + car.ModelName + " - " + colorManager.GetById(car.ColorId).name);
                }
            }

            Console.WriteLine("*******************************************6");

            // Rastgele car değerler oluşturma
            int randomBrandId1 = random.Next(1, 1000); // 1 ile 100 arasında rastgele bir Id
            string[] carBrandNames = {
                                        "Audi", "BMW", "Chevrolet", "Dodge", "Ferrari", "Ford", "Honda", "Hyundai",
                                        "Jaguar", "Jeep", "Kia", "Lamborghini", "Lexus", "Maserati", "Mazda",
                                        "Mercedes-Benz", "Mini", "Mitsubishi", "Nissan", "Porsche", "Ram",
                                        "Renault", "Rolls-Royce", "Subaru", "Tesla", "Toyota", "Volkswagen",
                                        "Volvo", "Alfa Romeo", "Aston Martin", "Bentley", "Bugatti", "Buick",
                                        "Cadillac", "Chrysler", "Fiat", "Genesis", "Infiniti", "Lincoln", "McLaren" };


            string randomBrandName1 = carBrandNames[random.Next(0, carBrandNames.Length)]; // Örnek araba isimlerinden rastgele bir Name

            Console.WriteLine("***Örnek araba isimlerinden rastgele bir Name***7");
            var result5 = carManager.GetById(40);
            Car carToUpdate = result5.Data;

            carToUpdate.BrandId = random.Next(1, 16);
            carToUpdate.ColorId = random.Next(1, 11);
            carToUpdate.ModelName = randomBrandName1 + " new model";
            carToUpdate.ModelYear = 2024;
            carToUpdate.DailyPrice = 1250000;
            carToUpdate.Description = "Some Description Text";

            carManager.Update(carToUpdate);

            Console.WriteLine("*******************************************8");
            var result6 = carManager.GetById(971);
            Car carToDelete = result6.Data;
            carManager.Delete(carToDelete);
            Console.WriteLine("*****Araç Detayları*************************9");
            var result7 = carManager.GetCarDetails();
            if (result7.IsSuccess == true)
            {
                foreach (var car in result7.Data)
                {
                    Console.WriteLine(car.CarName + " / " + car.BrandName + " / " + car.ColorName + " / " + car.DailyPrice);
                }
            }

        }
    }
}
