//author: adrian
//helpers:
//last_checked: futz@20.11.2015

using System;
using System.Data;
using System.Data.SqlClient;
using WcfServiceLibrary.MODEL;

namespace WcfServiceLibrary.DAL
{
    public class DbTexts : ITexts
    {
        //define sql parameters
        private static SqlParameter param_textId = new SqlParameter("@TextId", SqlDbType.Int);
        private static SqlParameter param_textData = new SqlParameter("@TextData", SqlDbType.NVarChar, 15);

        //
        private static Text createText(IDataReader dbReader)
        {
            Text text = new Text();
            text.textId = Convert.ToInt32(dbReader["TextId"]);
            text.textData = Convert.ToString(dbReader["TextData"]);
            return text;
        }

        //
        public int insertText(Text text)
        {
            int result = -1;

            string sqlQuery = "INSERT INTO Texts VALUES (" +
                "@TextData " +
            ")";

            using (SqlConnection sqlConnection = new SqlConnection(AccessTranslatoDb.sqlConnectionString))
            {
                try
                {
                    SqlCommand sqlCommand = new SqlCommand(sqlQuery, sqlConnection);
                    sqlCommand.Parameters.Clear();

                    param_textData.Value = text.textData;
                    sqlCommand.Parameters.Add(param_textData);

                    sqlCommand.Connection.Open();
                    result = sqlCommand.ExecuteNonQuery();

                    sqlCommand.Parameters.Clear();
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
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
                return result;
            }
        }
    }
}
