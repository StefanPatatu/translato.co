//author: adrian
//helpers: futz
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

        //dbReader
        private static Text createText(IDataReader dbReader)
        {
            Text text = new Text();
            text.textId = Convert.ToInt32(dbReader["TextId"]);
            text.textData = Convert.ToString(dbReader["TextData"]);
            return text;
        }

        //returns "1" if successful
        //returns "0" if not
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
                    result = 0;
                    DEBUG.Log.Add(ioEx.ToString());
                }
                catch (SqlException sqlEx)
                {
                    result = 0;
                    DEBUG.Log.Add(sqlEx.ToString());
                }
                catch (ArgumentException argEx)
                {
                    result = 0;
                    DEBUG.Log.Add(argEx.ToString());
                }
                catch (Exception ex)
                {
                    result = 0;
                    DEBUG.Log.Add(ex.ToString());
                }
                return result;
            }
        }

        //returns "MODEL.Text" object if successful
        //returns "null" if not
        public Text findTextById(int textId)
        {
            string sqlQuery = "SELECT * FROM Texts WHERE " +
                "TextId = @TextId";

            using (SqlConnection sqlConnection = new SqlConnection(AccessTranslatoDb.sqlConnectionString))
            {
                Text text = new Text();
                IDataReader dbReader;

                try
                {
                    SqlCommand sqlCommand = new SqlCommand(sqlQuery, sqlConnection);
                    sqlCommand.Parameters.Clear();

                    if (sqlCommand.Parameters.Contains(param_textId)) sqlCommand.Parameters.Remove(param_textId);
                    param_textId.Value = textId;
                    sqlCommand.Parameters.Add(param_textId);

                    sqlCommand.Connection.Open();
                    dbReader = sqlCommand.ExecuteReader();
                    if (dbReader.Read()) { text = createText(dbReader); }
                    else { text = null; }
                    sqlCommand.Connection.Close();

                    sqlCommand.Parameters.Clear();
                    if (sqlCommand.Parameters.Contains(param_textId)) sqlCommand.Parameters.Remove(param_textId);
                }
                catch (InvalidOperationException ioEx)
                {
                    text = null;
                    DEBUG.Log.Add(ioEx.ToString());
                }
                catch (SqlException sqlEx)
                {
                    text = null;
                    DEBUG.Log.Add(sqlEx.ToString());
                }
                catch (ArgumentException argEx)
                {
                    text = null;
                    DEBUG.Log.Add(argEx.ToString());
                }
                catch (Exception ex)
                {
                    text = null;
                    DEBUG.Log.Add(ex.ToString());
                }
                return text;
            }
        }
    }
}
