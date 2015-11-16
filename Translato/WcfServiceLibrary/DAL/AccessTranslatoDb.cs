using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using G = System.Configuration;   // System.Configuration.dll
using D = System.Data;            // System.Data.dll
using C = System.Data.SqlClient;  // System.Data.dll
using T = System.Text;

namespace WcfServiceLibrary.DAL
{
    internal class AccessTranslatoDb
    {
        internal static string SQLConnectionString = "Server=tcp:translato.database.windows.net,1433;Database=TranslatoDb;User ID=futz_translato@translato;Password=KLtQokRAmYLEvqvCx6VhKzBP6lqMeT9V;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
    }
}
