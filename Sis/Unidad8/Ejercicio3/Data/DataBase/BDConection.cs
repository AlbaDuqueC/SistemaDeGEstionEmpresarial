using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.DataBase
{
    public class BDConection
    {

        public static String getConnectionString()
        {
            return "server=duque.database.windows.net;database=PersonasDB;uid=prueba5;pwd=Abcd1234!;trustServerCertificate = true;";
        }

    }
}
