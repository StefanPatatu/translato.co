//author: adrian
//helpers:
//last_checked: futz@20.11.2015

using System;
using System.Data;
using System.Data.SqlClient;
using WcfServiceLibrary.MODEL;

namespace WcfServiceLibrary.DAL
{
    public class DbLanguages : ILanguages
    {
        //define sql parameters
        private static SqlParameter param_languageId = new SqlParameter("@LanguageId", SqlDbType.Int);
        private static SqlParameter param_languageName = new SqlParameter("@LanguageName", SqlDbType.NVarChar,15);
        
        //
        private static Language createLanguage(IDataReader dbReader)
        {
            Language language = new Language();
            language.languageId = Convert.ToInt32(dbReader["LanguageId"]);
            language.languageName = Convert.ToString(dbReader["LanguageName"]);
            return language;
        }

        //
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
