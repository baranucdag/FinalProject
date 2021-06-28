using Entities.Conscrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constans
{
    public static class Messages            //static sınıflar new'lenmeye ihtiyaç duymaz.
    {                                       //burada sabit mesajlar yazılır.
        public static string ProductAdded = "Product added.";
        public static string ProductNameİnvalid = "Given product name is invalid!";
        public static string MaintenanceTime="system is currently under maintenance!";
        public static string ProductListed="Producs has been listed";
    }
}
