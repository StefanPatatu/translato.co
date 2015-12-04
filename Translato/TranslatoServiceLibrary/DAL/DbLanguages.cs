//author: adrian
//helpers: futz
//last_checked: futz@04.12.2015

using System;
using System.Data;
using System.Data.SqlClient;
using TranslatoServiceLibrary.MODEL;

namespace TranslatoServiceLibrary.DAL
{
    internal sealed class DbLanguages : ILanguages
    {
        //define sql parameters
        private static SqlParameter param_languageId = new SqlParameter("@LanguageId", SqlDbType.Int);
        private static SqlParameter param_languageName = new SqlParameter("@LanguageName", SqlDbType.NVarChar,15);
        
        //dbReader
        private static Language createLanguage(IDataReader dbReader)
        {
            Language language = new Language();
            language.languageId = Convert.ToInt32(dbReader["LanguageId"]);
            language.languageName = Convert.ToString(dbReader["LanguageName"]);
            return language;
        }

        //returns
        //returns
        //todo@futz
        public int insertLanguage(Language language)
        {
            int result = -1;

            string sqlQuery = "INSERT INTO Languages VALUES (" +
                "@LanguageName " +
            ")";

            using (SqlConnection sqlConnection = new SqlConnection(AccessTranslatoDb.sqlConnectionString))
            {
                try
                {
                    SqlCommand sqlCommand = new SqlCommand(sqlQuery, sqlConnection);
                    sqlCommand.Parameters.Clear();

                    param_languageName.Value = language.languageName;
                    sqlCommand.Parameters.Add(param_languageName);

                    sqlCommand.Connection.Open();
                    result = sqlCommand.ExecuteNonQuery();

                    sqlCommand.Parameters.Clear();
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
