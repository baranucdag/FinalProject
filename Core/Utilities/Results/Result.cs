using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{
    public class Result : IResult
    {                                               //constructor yapmamızın nedeni: bazen sadece succes çalıştırıp mesaj gönermek istemeyebiliriz. bu nedenle constructor kullanırırz.
        public Result(bool succes, string message):this(succes) //her ikisini çalıştırmak için this(classın kendisi) gönderildi.
        {                                                       //ilk Result çalıştığında tek parametreli olanı da çalıştır.
            Message = message;                                  //iki parametreli constructer ççalıştığında tek parametreli olanı da çalıştır.
        }                                                               
        public Result(bool succes)                              
        {
            Succes = Succes;
        }

        public bool Succes { get; }

        public string Message { get; }
    }
}
