//author: adrian
//helpers: futz
//last_checked: futz@11.12.2015
//talked about with Alex

using ENUM;
using System;
using System.Data;
using System.Data.SqlClient;
using TranslatoServiceLibrary.MODEL;
using TranslatoServiceLibrary.X;

namespace TranslatoServiceLibrary.DAL
{
    internal sealed class DbTexts : ITexts
    {
        //define sql parameters
        private SqlParameter param_textId;
        private SqlParameter param_textData;
        //regenerate sql parameters
        private void regenSqlParams()
        {
            param_textId = new SqlParameter("@TextId", SqlDbType.Int);
            param_textData = new SqlParameter("@TextData", SqlDbType.NVarChar, 40000);
        }

        //dbReader
        private static Text createText(IDataReader dbReader)
        {
            Text text = new Text();
            text.textId = Convert.ToInt32(dbReader["TextId"]);
            text.textData = Convert.ToString(dbReader["TextData"]);
            return text;
        }

        //returns [int >= TRANSLATO_DATABASE_SEED] if successful
        //returns [int < TRANSLATO_DATABASE_SEED] if not
        public int insertText(Text text)
        {
            int returnCode = (int)CODE.ZERO;

            string sqlQuery = "INSERT INTO Texts OUTPUT INSERTED.TextId VALUES (" +
                "@TextData " +
            ")";

            using (SqlConnection sqlConnection = new SqlConnection(AccessTranslatoDb.sqlConnectionString))
            {
                try
                {
                    regenSqlParams();
                    using (SqlCommand sqlCommand = new SqlCommand(sqlQuery, sqlConnection))
                    {
                        param_textData.Value = text.textData;
                        sqlCommand.Parameters.Add(param_textData);

                        sqlCommand.Connection.Open();
                        returnCode = (int)sqlCommand.ExecuteScalar();
                        sqlCommand.Connection.Close();

                        sqlCommand.Parameters.Clear();
                    }
                }
                catch (InvalidOperationException ioEx)
                {
                    returnCode = (int)CODE.DBTEXTS_INSERTTEXT_EXCEPTION;
                    Log.Add(ioEx.ToString());
                }
                catch (SqlException sqlEx)
                {
                    returnCode = (int)CODE.DBTEXTS_INSERTTEXT_EXCEPTION;
                    Log.Add(sqlEx.ToString());
                }
                catch (ArgumentException argEx)
                {
                    returnCode = (int)CODE.DBTEXTS_INSERTTEXT_EXCEPTION;
                    Log.Add(argEx.ToString());
                }
                catch (Exception ex)
                {
                    returnCode = (int)CODE.DBTEXTS_INSERTTEXT_EXCEPTION;
                    Log.Add(ex.ToString());
                }
                return returnCode;
            }
        }

        //returns "MODEL.Text" object if successful
        //returns "null" if not
        public Text findTextByTextId(int textId)
        {
            string sqlQuery = "SELECT * FROM Texts WHERE " +
                "TextId = @TextId";

            using (SqlConnection sqlConnection = new SqlConnection(AccessTranslatoDb.sqlConnectionString))
            {
                Text text = new Text();
                IDataReader dbReader;

                try
                {
                    regenSqlParams();
                    using (SqlCommand sqlCommand = new SqlCommand(sqlQuery, sqlConnection))
                    {
                        param_textId.Value = textId;
                        sqlCommand.Parameters.Add(param_textId);

                        sqlCommand.Connection.Open();
                        dbReader = sqlCommand.ExecuteReader();
                        if (dbReader.Read()) { text = createText(dbReader); }
                        else { text = null; }
                        sqlCommand.Connection.Close();

                        sqlCommand.Parameters.Clear();
                    }
                }
                catch (InvalidOperationException ioEx)
                {
                    text = null;
                    Log.Add(ioEx.ToString());
                }
                catch (SqlException sqlEx)
                {
                    text = null;
                    Log.Add(sqlEx.ToString());
                }
                catch (ArgumentException argEx)
                {
                    text = null;
                    Log.Add(argEx.ToString());
                }
                catch (Exception ex)
                {
                    text = null;
                    Log.Add(ex.ToString());
                }
                return text;
            }
        }
    }
}
