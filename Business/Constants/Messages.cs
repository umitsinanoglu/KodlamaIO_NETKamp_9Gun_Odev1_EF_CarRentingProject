using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public static class Messages
    {
        public static string CarNameInvalid = "Araç ismi en az 3 harfli olmalıdır, Araç Eklenemedi";
        public static string CarAdded = "Araç başarı ile eklendi";
        public static string CarUpdated = "Araç başarı ile güncellendi";
        public static string CarDeleted = "Araç başarı ile silindi";
        public static string CarsListed = "Araçlar listelendi";
        public static string CarListed = "Araç listelendi";
        public static string MaintenanceTime = "Sistem Bakımda";
        public static string CarIdInvalid = "Araç id hatalı.";
        public static string ColorIdInvalid = "Araç renk id hatalı.";
        public static string BrandIdInvalid = "Araç model id hatalı.";
    }
}
