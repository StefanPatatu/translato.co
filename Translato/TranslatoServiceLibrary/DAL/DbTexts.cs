//author: adrian
//helpers:
//last_checked: futz@03.12.2015

using System;
using System.Data;
using System.Data.SqlClient;
using TranslatoServiceLibrary.MODEL;

namespace TranslatoServiceLibrary.DAL
{
    public class DbTexts : ITexts
    {
        //define sql parameters
        private static SqlParameter param_textId = new SqlParameter("@TextId", SqlDbType.Int);
        private static SqlParameter param_textData = new SqlParameter("@TextData", SqlDbType.NVarChar, 40000);

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
            int result = 0;

            string sqlQuery = "INSERT INTO Texts VALUES (" +
                "@TextData " +
            ")";

            using (SqlConnection sqlConnection = new SqlConnection(AccessTranslatoDb.sqlConnectionString))
            {
                try
                {
                    SqlCommand sqlCommand = new SqlCommand(sqlQuery, sqlConnection);
                    sqlCommand.Parameters.Clear();

                    if (sqlCommand.Parameters.Contains(param_textData)) sqlCommand.Parameters.Remove(param_textData);
                    param_textData.Value = text.textData;
                    sqlCommand.Parameters.Add(param_textData);

                    sqlCommand.Connection.Open();
                    result = sqlCommand.ExecuteNonQuery();
                    sqlCommand.Connection.Close();

                    sqlCommand.Parameters.Clear();
                    if (sqlCommand.Parameters.Contains(param_textData)) sqlCommand.Parameters.Remove(param_textData);

                    sqlCommand.Dispose();
                }
                catch (InvalidOperationException ioEx)
                {
                    DEBUG.Log.Add(ioEx.ToString());
                }
                catch (SqlException sqlEx)
                {
                    DEBUG.Log.Add(sqlEx.ToString());
                }
                catch (ArgumentException argEx)
                {
                    DEBUG.Log.Add(argEx.ToString());
                }
                catch (Exception ex)
                {
                    DEBUG.Log.Add(ex.ToString());
                }
                return result;
            }
        }
    }
}
