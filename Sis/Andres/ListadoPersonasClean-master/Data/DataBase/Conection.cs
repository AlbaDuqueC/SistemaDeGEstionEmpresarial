using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.DataBase
{
    internal class Conection
    {
        public static string GetConnectionString()
        {
            return "server=andres-ojeda.database.windows.net;database=PersonasDB;uid=andresojeda;pwd=andres.ojeda66!;trustServerCertificate = true;";
        }
    }
}
