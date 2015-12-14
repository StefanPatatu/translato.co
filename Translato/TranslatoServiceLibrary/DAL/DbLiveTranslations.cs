//author: futz
//helpers: 
//last_checked: futz@14.12.2015

using ENUM;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using TranslatoServiceLibrary.MODEL;
using TranslatoServiceLibrary.X;

namespace TranslatoServiceLibrary.DAL
{
    internal sealed class DbLiveTranslations : ILiveTranslations
    {
        //define sql parameters
        private SqlParameter param_liveTranslationId;
        private SqlParameter param_dateCreated;
        private SqlParameter param_providerId;
        private SqlParameter param_pricePerHour;
        private SqlParameter param_language1Id;
        private SqlParameter param_language2Id;
        private SqlParameter param_language3Id;
        private SqlParameter param_language4Id;
        private SqlParameter param_language5Id;
        private SqlParameter param_dateStarted;
        private SqlParameter param_requesterId;
        private SqlParameter param_dateEnded;
        //regenerate sql parameters
        private void regenSqlParams()
        {
            param_liveTranslationId = new SqlParameter("@LiveTranslationId", SqlDbType.Int);
            param_dateCreated = new SqlParameter("@DateCreated", SqlDbType.DateTimeOffset);
            param_providerId = new SqlParameter("@ProviderId", SqlDbType.Int);
            param_pricePerHour = new SqlParameter("@PricePerHour", SqlDbType.Decimal);
            param_language1Id = new SqlParameter("@Language1Id", SqlDbType.Int);
            param_language2Id = new SqlParameter("@Language2Id", SqlDbType.Int);
            param_language3Id = new SqlParameter("@Language3Id", SqlDbType.Int);
            param_language4Id = new SqlParameter("@Language4Id", SqlDbType.Int);
            param_language5Id = new SqlParameter("@Language5Id", SqlDbType.Int);
            param_dateStarted = new SqlParameter("@DateStarted", SqlDbType.DateTimeOffset);
            param_requesterId = new SqlParameter("@RequesterId", SqlDbType.Int);
            param_dateEnded = new SqlParameter("@DateEnded", SqlDbType.DateTimeOffset);
        }

        //dbReader
        private static LiveTranslation createLiveTranslation(IDataReader dbReader)
        {
            LiveTranslation liveTranslation = new LiveTranslation();
            liveTranslation.liveTranslationId = Convert.ToInt32(dbReader["LiveTranslationId"]);
            liveTranslation.dateCreated = (DateTimeOffset)dbReader["DateCreated"];
            liveTranslation.provider = new User();
            liveTranslation.provider.userId = Convert.ToInt32(dbReader["ProviderId"]);
            liveTranslation.pricePerHour = Convert.ToDecimal(dbReader["PricePerHour"]);
            liveTranslation.language1 = new Language();
            liveTranslation.language1.languageId = Convert.ToInt32(dbReader["Language1Id"]);
            liveTranslation.language2 = new Language();
            liveTranslation.language2.languageId = Convert.ToInt32(dbReader["Language2Id"]);
            if (dbReader["Language3Id"] != null && dbReader["Language3Id"] != DBNull.Value)
            {
                liveTranslation.language3 = new Language();
                liveTranslation.language3.languageId = Convert.ToInt32(dbReader["Language3Id"]);
            }
            else liveTranslation.language3 = null;
            if (dbReader["Language4Id"] != null && dbReader["Language4Id"] != DBNull.Value)
            {
                liveTranslation.language4 = new Language();
                liveTranslation.language4.languageId = Convert.ToInt32(dbReader["Language4Id"]);
            }
            else liveTranslation.language4 = null;
            if (dbReader["Language5Id"] != null && dbReader["Language5Id"] != DBNull.Value)
            {
                liveTranslation.language5 = new Language();
                liveTranslation.language5.languageId = Convert.ToInt32(dbReader["Language5Id"]);
            }
            else liveTranslation.language5 = null;
            if (dbReader["DateStarted"] != null && dbReader["DateStarted"] != DBNull.Value)
            {
                liveTranslation.dateStarted = (DateTimeOffset)dbReader["DateStarted"];
            }
            else liveTranslation.dateStarted = null;
            if (dbReader["RequesterId"] != null && dbReader["RequesterId"] != DBNull.Value)
            {
                liveTranslation.requester = new User();
                liveTranslation.requester.userId = Convert.ToInt32(dbReader["RequesterId"]);
            }
            else liveTranslation.requester = null;
            if (dbReader["DateEnded"] != null && dbReader["DateEnded"] != DBNull.Value)
            {
                liveTranslation.dateEnded = (DateTimeOffset)dbReader["DateEnded"];
            }
            else liveTranslation.dateEnded = null;
            return liveTranslation;
        }
    }
}
