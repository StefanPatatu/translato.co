using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace WcfServiceLibrary.DAL
{
    internal class AccessTranslatoDb
    {
        private static string connectionString = @"Data Source=translato.database.windows.net;Integrated Security=False;User ID=futz_translato;Password=KLtQokRAmYLEvqvCx6VhKzBP6lqMeT9V;Connect Timeout=60;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        private static SqlConnection dbConnection = new SqlConnection(connectionString);
        private static SqlCommand dbCommand = new SqlCommand(null, dbConnection);
        internal static void Open()
        {
            if(dbConnection.State != ConnectionState.Open && dbConnection.State != ConnectionState.Connecting)
            {
                dbConnection.Close();
                dbConnection.Open();
            }
        }
        internal static void Close()
        {
            dbConnection.Close();
        }

        internal static SqlCommand GetDbCommand(string sqlQuery)
        {
            if(dbConnection.State == ConnectionState.Open)
            {
                Close();
            }
            Open();
            if(dbCommand == null)
            {
                dbCommand = new SqlCommand(sqlQuery, dbConnection);
            }
            else
            {
                dbCommand.CommandText = sqlQuery;
            }
            return dbCommand;
        }
    }
}
