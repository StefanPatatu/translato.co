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
    public class DbTexts : ITexts
    {
        private static SqlCommand sqlCommand = null;
        private static SqlParameter param_TextId = new SqlParameter("@TextId", SqlDbType.Int);
        private static SqlParameter param_TextData = new SqlParameter("@TextData", SqlDbType.NVarChar, 15);


        private static Text createText(IDataReader dbReader)
        {
            Text text = new Text();
            text.TextId = Convert.ToInt32(dbReader["TextId"]);
            text.TextData = Convert.ToString(dbReader["TextData"]);

            return text;
        }

        public int insertText(Text text)
        {
            int result = -1;

            string sqlQuery = "INSERT INTO Texts VALUES (" +
                "@TextData " +

            ")";

            using (SqlConnection sqlConnection = new SqlConnection(AccessTranslatoDb.SQLConnectionString))
            {
                try
                {
                    SqlCommand sqlCommand = new SqlCommand(sqlQuery, sqlConnection);

                    param_TextData.Value = text.TextData;
                    sqlCommand.Parameters.Add(param_TextData);



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
