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
            return "server=duque.database.windows.net;database=PersonaDB;uid=prueba;pwd=.1234abcd.;trustServerCertificate = true;";
        }

    }
}
