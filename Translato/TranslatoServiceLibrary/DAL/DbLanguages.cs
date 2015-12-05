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

        //returns "1" if successful
        //returns "0" if not
        public int insertLanguage(Language language)
        {
            int result = 0;

            string sqlQuery = "INSERT INTO Languages VALUES (" +
                "@LanguageName " +
            ")";

            using (SqlConnection sqlConnection = new SqlConnection(AccessTranslatoDb.sqlConnectionString))
            {
                try
                {
                    SqlCommand sqlCommand = new SqlCommand(sqlQuery, sqlConnection);
                    sqlCommand.Parameters.Clear();

                    if (sqlCommand.Parameters.Contains(param_languageName)) sqlCommand.Parameters.Remove(param_languageName);
                    param_languageName.Value = language.languageName;
                    sqlCommand.Parameters.Add(param_languageName);

                    sqlCommand.Connection.Open();
                    result = sqlCommand.ExecuteNonQuery();
                    sqlCommand.Connection.Close();

                    sqlCommand.Parameters.Clear();
                    if (sqlCommand.Parameters.Contains(param_languageName)) sqlCommand.Parameters.Remove(param_languageName);

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

        //returns "Model.Language" object if successful
        //returns "null" if not
        public Language findLanguageByLanguageId(int languageId)
        {
            string sqlQuery = "SELECT * FROM Languages WHERE " +
                "LanguageId = @LanguageId";

            using (SqlConnection sqlConnection = new SqlConnection(AccessTranslatoDb.sqlConnectionString))
            {
                Language language = new Language();
                IDataReader dbReader;

                try
                {
                    SqlCommand sqlCommand = new SqlCommand(sqlQuery, sqlConnection);
                    sqlCommand.Parameters.Clear();

                    if (sqlCommand.Parameters.Contains(param_languageId)) sqlCommand.Parameters.Remove(param_languageId);
                    param_languageId.Value = languageId;
                    sqlCommand.Parameters.Add(param_languageId);

                    sqlCommand.Connection.Open();
                    dbReader = sqlCommand.ExecuteReader();
                    if (dbReader.Read()) { language = createLanguage(dbReader); }
                    else { language = null; }
                    sqlCommand.Connection.Close();

                    sqlCommand.Parameters.Clear();
                    if (sqlCommand.Parameters.Contains(param_languageId)) sqlCommand.Parameters.Remove(param_languageId);
                }
                catch (InvalidOperationException ioEx)
                {
                    language = null;
                    DEBUG.Log.Add(ioEx.ToString());
                }
                catch (SqlException sqlEx)
                {
                    language = null;
                    DEBUG.Log.Add(sqlEx.ToString());
                }
                catch (ArgumentException argEx)
                {
                    language = null;
                    DEBUG.Log.Add(argEx.ToString());
                }
                catch (Exception ex)
                {
                    language = null;
                    DEBUG.Log.Add(ex.ToString());
                }
                return language;
            }
        }

        //returns "MODEL.Language" object if successful
        //returns "null" if not
        public Language findLanguageByLanguageName(string languageName)
        {
            string sqlQuery = "SELECT * FROM Languages WHERE " +
                "LanguageName = @LanguageNname";

            using (SqlConnection sqlConnection = new SqlConnection(AccessTranslatoDb.sqlConnectionString))
            {
                Language language = new Language();
                IDataReader dbReader;

                try
                {
                    SqlCommand sqlCommand = new SqlCommand(sqlQuery, sqlConnection);
                    sqlCommand.Parameters.Clear();

                    if (sqlCommand.Parameters.Contains(param_languageName)) sqlCommand.Parameters.Remove(param_languageName);
                    param_languageName.Value = languageName;
                    sqlCommand.Parameters.Add(param_languageName);

                    sqlCommand.Connection.Open();
                    dbReader = sqlCommand.ExecuteReader();
                    if (dbReader.Read()) { language = createLanguage(dbReader); }
                    else { language = null; }
                    sqlCommand.Connection.Close();

                    sqlCommand.Parameters.Clear();
                    if (sqlCommand.Parameters.Contains(param_languageName)) sqlCommand.Parameters.Remove(param_languageName);
                }
                catch (InvalidOperationException ioEx)
                {
                    language = null;
                    DEBUG.Log.Add(ioEx.ToString());
                }
                catch (SqlException sqlEx)
                {
                    language = null;
                    DEBUG.Log.Add(sqlEx.ToString());
                }
                catch (ArgumentException argEx)
                {
                    language = null;
                    DEBUG.Log.Add(argEx.ToString());
                }
                catch (Exception ex)
                {
                    language = null;
                    DEBUG.Log.Add(ex.ToString());
                }
                return language;
            }
        }
    }
}

