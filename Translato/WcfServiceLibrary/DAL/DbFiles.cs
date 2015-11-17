using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using WcfServiceLibrary.MODEL;

namespace WcfServiceLibrary.DAL
{
    public class DbFiles : IFiles
    {
        private static SqlCommand sqlCommand = null;
        private static SqlParameter param_TextId = new SqlParameter("@FileId", SqlDbType.Int);
        


        private static File createFile(IDataReader dbReader)
        {
            File file = new File();
            file.FileId = Convert.ToInt32(dbReader["TextId"]);
            

            return file;
        }

        public int insertFile(File file)
        {
            int result = -1;

            string sqlQuery = "INSERT INTO Files DEFAULT VALUES";

            using (SqlConnection sqlConnection = new SqlConnection(AccessTranslatoDb.SQLConnectionString))
            {
                try
                {
                    SqlCommand sqlCommand = new SqlCommand(sqlQuery, sqlConnection);

                    



                    sqlCommand.Connection.Open();
                    result = sqlCommand.ExecuteNonQuery();
                }
                catch (InvalidOperationException ioEx)
                {
                    Console.WriteLine(ioEx.ToString());
                }
                catch (SqlException sqlEx)
                {
                    Console.WriteLine(sqlEx.ToString());
                }
                catch (ArgumentException argEx)
                {
                    Console.WriteLine(argEx.ToString());
                }
                return result;
            }
        }
    }
}
