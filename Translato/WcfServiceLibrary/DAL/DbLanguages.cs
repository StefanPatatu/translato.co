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
    public class DbLanguages : ILanguages
    {
        private static SqlCommand sqlCommand = null;
        private static SqlParameter param_LanguageId = new SqlParameter("@LanguageId", SqlDbType.Int);
        private static SqlParameter param_LanguageName = new SqlParameter("@LanguageName", SqlDbType.NVarChar,15);
        

        private static Language createLanguage(IDataReader dbReader)
        {
            Language language = new Language();
            language.LanguageId = Convert.ToInt32(dbReader["LanguageId"]);
            language.LanguageName = Convert.ToString(dbReader["LanguageName"]);
            
            return language;
        }

        public int insertLanguage(Language language)
        {
            int result = -1;

            string sqlQuery = "INSERT INTO Languages VALUES (" +
                "@LanguageName, " +
                
            ")";

            using (SqlConnection sqlConnection = new SqlConnection(AccessTranslatoDb.SQLConnectionString))
            {
                try
                {
                    SqlCommand sqlCommand = new SqlCommand(sqlQuery, sqlConnection);

                    param_LanguageName.Value = language.LanguageName;
                    sqlCommand.Parameters.Add(param_LanguageName);

                   

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
