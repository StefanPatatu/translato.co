//author: adrian
//helpers: futz
//last_checked: futz@10.12.2015

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using TranslatoServiceLibrary.MODEL;
using TranslatoServiceLibrary.X;

namespace TranslatoServiceLibrary.DAL
{
    internal sealed class DbLanguages : ILanguages
    {
        //define sql parameters
        private SqlParameter param_languageId;
        private SqlParameter param_languageName;
        //regenerate sql parameters
        private void regenSqlParams()
        {
            param_languageId = new SqlParameter("@LanguageId", SqlDbType.Int);
            param_languageName = new SqlParameter("@LanguageName", SqlDbType.NVarChar, 15);
        }

        //dbReader
        private static Language createLanguage(IDataReader dbReader)
        {
            Language language = new Language();
            language.languageId = Convert.ToInt32(dbReader["LanguageId"]);
            language.languageName = Convert.ToString(dbReader["LanguageName"]);
            return language;
        }

        //returns [int >= TRANSLATO_DATABASE_SEED] if successful
        //returns [int < TRANSLATO_DATABASE_SEED] if not
        public int insertLanguage(Language language)
        {
            int returnCode = (int)CODE.ZERO;

            string sqlQuery = "INSERT INTO Languages OUTPUT INSERTED.LanguageId VALUES (" +
                "@LanguageName" +
            ")";

            using (SqlConnection sqlConnection = new SqlConnection(AccessTranslatoDb.sqlConnectionString))
            {
                try
                {
                    regenSqlParams();
                    using (SqlCommand sqlCommand = new SqlCommand(sqlQuery, sqlConnection))
                    {
                        param_languageName.Value = language.languageName;
                        sqlCommand.Parameters.Add(param_languageName);

                        sqlCommand.Connection.Open();
                        returnCode = (int)sqlCommand.ExecuteScalar();
                        sqlCommand.Connection.Close();

                        sqlCommand.Parameters.Clear();
                    }
                }
                catch (InvalidOperationException ioEx)
                {
                    returnCode = (int)CODE.DBLANGUAGES_INSERTLANGUAGE_EXCEPTION;
                    Log.Add(ioEx.ToString());
                }
                catch (SqlException sqlEx)
                {
                    returnCode = (int)CODE.DBLANGUAGES_INSERTLANGUAGE_EXCEPTION;
                    Log.Add(sqlEx.ToString());
                }
                catch (ArgumentException argEx)
                {
                    returnCode = (int)CODE.DBLANGUAGES_INSERTLANGUAGE_EXCEPTION;
                    Log.Add(argEx.ToString());
                }
                catch (Exception ex)
                {
                    returnCode = (int)CODE.DBLANGUAGES_INSERTLANGUAGE_EXCEPTION;
                    Log.Add(ex.ToString());
                }
                return returnCode;
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
                    regenSqlParams();
                    using (SqlCommand sqlCommand = new SqlCommand(sqlQuery, sqlConnection))
                    {
                        param_languageId.Value = languageId;
                        sqlCommand.Parameters.Add(param_languageId);

                        sqlCommand.Connection.Open();
                        dbReader = sqlCommand.ExecuteReader();
                        if (dbReader.Read()) { language = createLanguage(dbReader); }
                        else { language = null; }
                        sqlCommand.Connection.Close();

                        sqlCommand.Parameters.Clear();
                    }
                }
                catch (InvalidOperationException ioEx)
                {
                    language = null;
                    Log.Add(ioEx.ToString());
                }
                catch (SqlException sqlEx)
                {
                    language = null;
                    Log.Add(sqlEx.ToString());
                }
                catch (ArgumentException argEx)
                {
                    language = null;
                    Log.Add(argEx.ToString());
                }
                catch (Exception ex)
                {
                    language = null;
                    Log.Add(ex.ToString());
                }
                return language;
            }
        }

        //returns "Model.Language" object if successful
        //returns "null" if not
        public Language findLanguageByLanguageName(string languageName)
        {
            string sqlQuery = "SELECT * FROM Languages WHERE " +
                "LanguageName = @LanguageName";

            using (SqlConnection sqlConnection = new SqlConnection(AccessTranslatoDb.sqlConnectionString))
            {
                Language language = new Language();
                IDataReader dbReader;

                try
                {
                    regenSqlParams();
                    using (SqlCommand sqlCommand = new SqlCommand(sqlQuery, sqlConnection))
                    {
                        param_languageName.Value = languageName;
                        sqlCommand.Parameters.Add(param_languageName);

                        sqlCommand.Connection.Open();
                        dbReader = sqlCommand.ExecuteReader();
                        if (dbReader.Read()) { language = createLanguage(dbReader); }
                        else { language = null; }
                        sqlCommand.Connection.Close();

                        sqlCommand.Parameters.Clear();
                    }
                }
                catch (InvalidOperationException ioEx)
                {
                    language = null;
                    Log.Add(ioEx.ToString());
                }
                catch (SqlException sqlEx)
                {
                    language = null;
                    Log.Add(sqlEx.ToString());
                }
                catch (ArgumentException argEx)
                {
                    language = null;
                    Log.Add(argEx.ToString());
                }
                catch (Exception ex)
                {
                    language = null;
                    Log.Add(ex.ToString());
                }
                return language;
            }
        }

        //returns "List<MODEL.Language>" object if successful
        //returns "null" if not
        public List<Language> getAllLanguages()
        {
            string sqlQuery = "SELECT * FROM Languages " +
                "ORDER BY LanguageName ASC";

            using (SqlConnection sqlConnection = new SqlConnection(AccessTranslatoDb.sqlConnectionString))
            {
                List<Language> languages = new List<Language>();
                IDataReader dbReader;

                try
                {
                    regenSqlParams();
                    using (SqlCommand sqlCommand = new SqlCommand(sqlQuery, sqlConnection))
                    {
                        sqlCommand.Connection.Open();
                        dbReader = sqlCommand.ExecuteReader();
                        while (dbReader.Read())
                        {
                            Language language = createLanguage(dbReader);
                            languages.Add(language);
                        }
                        sqlCommand.Connection.Close();

                        sqlCommand.Parameters.Clear();
                    }
                }
                catch (InvalidOperationException ioEx)
                {
                    languages = null;
                    Log.Add(ioEx.ToString());
                }
                catch (SqlException sqlEx)
                {
                    languages = null;
                    Log.Add(sqlEx.ToString());
                }
                catch (ArgumentException argEx)
                {
                    languages = null;
                    Log.Add(argEx.ToString());
                }
                catch (Exception ex)
                {
                    languages = null;
                    Log.Add(ex.ToString());
                }
                return languages;
            }
        }
    }
}

