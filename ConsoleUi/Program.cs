using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System.ComponentModel;

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

            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.Id + " - " + car.ModelName);
            }
            Console.WriteLine("*******************************************");
            Console.WriteLine(carManager.GetById(randomId).ModelName);
            Console.WriteLine("*******************************************");

            Console.WriteLine("*******************************************");
            foreach (var car in carManager.GetAllByDailyPriceRange(9000, 990000))
            {
                Console.WriteLine(car.Id + " - " + car.ModelName + " - " + car.DailyPrice);
            }
            Console.WriteLine("*******************************************");

            BrandManager brandManager = new BrandManager(new EfBrandDal());
            foreach (var car in carManager.GetCarsByBrandId(randomBrandId))
            {
                Console.WriteLine(car.Id + " - " + car.ModelName + " - " + brandManager.GetById(car.BrandId).name);
            }

            Console.WriteLine("*******************************************");
            ColorManager colorManager = new ColorManager(new EfColorDal());
            foreach (var car in carManager.GetCarsByColorId(randomColorId))
            {
                Console.WriteLine(car.Id + " - " + car.ModelName + " - " + colorManager.GetById(car.ColorId).name);
            }

            Console.WriteLine("*******************************************");

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
            
            Console.WriteLine("*******************************************");

            Car carToUpdate = carManager.GetById(40);
            
            carToUpdate.BrandId = random.Next(1, 16);
            carToUpdate.ColorId = random.Next(1, 11);
            carToUpdate.ModelName = randomBrandName1 + " new model";
            carToUpdate.ModelYear = 2024;
            carToUpdate.DailyPrice = 1250000;
            carToUpdate.Description = "Some Description Text";

            carManager.Update(carToUpdate);

            Console.WriteLine("*******************************************");
            Car carToDelete = carManager.GetById(48);
            carManager.Delete(carToDelete);
            Console.WriteLine("*****Araç Detayları**************************************");

            foreach (var car in carManager.GetCarDetails())
            {
                Console.WriteLine(car.CarName + " / " + car.BrandName + " / " + car.ColorName + " / " + car.DailyPrice );
            }
            

            //Car, Brand, Color sınıflarınız için tüm CRUD operasyonlarını hazır hale getiriniz.
            //Console'da Tüm CRUD operasyonlarınızı Car, Brand, Model nesneleriniz için test ediniz. GetAll, GetById, Insert, Update, Delete.
            //Arabaları şu bilgiler olacak şekilde listeleyiniz. CarName, BrandName, ColorName, DailyPrice. (İpucu: IDto oluşturup 3 tabloya join yazınız)

        }
    }
}
