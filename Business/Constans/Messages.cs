using Core.Entities.Concrete;
using Core.Utilities.Results;
using Entities.Conscrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
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
        public static string ProductAmountOfCategoryError = "Amount of category Error.";
        public static string ProductNameExist = "Product name already available";
        public static string CategoryLimitExceted="Amount of category already over 15";
        public static string AuthorizationDenied = "yetkiniz yok";
        public static string UserRegistered = "User registered";
        public static string UserNotFound = "User couldn't found";
        public static string PasswordError = "Plase check password";
        public static string SuccessfulLogin = "Succes login";
        public static string UserAlreadyExists = "User already exist. Please check it";
        public static string AccessTokenCreated = "Acces token created";
    }
}
