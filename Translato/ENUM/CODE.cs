//author: futz
//helpers:
//last_cheked: futz@13.12.2015

namespace ENUM
{
    //format: XXYYZZ
    //XX = class code | YY = method code | ZZ = error code
    public enum CODE : int
    {
        //SHIT
        //--------------------------------------------------
        ZERO = 0, //fucking 0
        MINUS_ONE = -1, //fucking -1
        //GENERAL(XX) = 99
        //GENERAL(YY) = 99
        CLIENT_NOT_AUTHORIZED = 999910,
        //DB SEED
        TRANSLATO_DATABASE_SEED = 1000000,
        //(XX) MULTIPLICATION
        XX = 10000,
        //(YY) MULTIPLICATION
        YY = 100,
        //GENERAL PURPOSE
        DAL_ERROR = 77,
        EXCEPTION = 88,
        SUCCESS = 99,
        //--------------------------------------------------

        //USER
        //--------------------------------------------------
        //DBUSERS
        DBUSERS = XX * 10,
        DBUSERS_INSERTUSER = DBUSERS + (YY * 10),
        DBUSERS_INSERTUSER_EXCEPTION = DBUSERS_INSERTUSER + 88,
        //CTRUSER
        CTRUSER = XX * 11,
        CTRUSER_INSERTUSER = CTRUSER + (YY * 10),
        CTRUSER_INSERTUSER_INVALID_USERNAME = CTRUSER_INSERTUSER + 10,
        CTRUSER_INSERTUSER_INVALID_PASSWORD = CTRUSER_INSERTUSER + 11,
        CTRUSER_INSERTUSER_INVALID_FIRSTNAME = CTRUSER_INSERTUSER + 12,
        CTRUSER_INSERTUSER_INVALID_LASTNAME = CTRUSER_INSERTUSER + 13,
        CTRUSER_INSERTUSER_INVALID_EMAIL = CTRUSER_INSERTUSER + 14,
        CTRUSER_INSERTUSER_DAL_ERROR = CTRUSER_INSERTUSER + DAL_ERROR,
        CTRUSER_INSERTUSER_EXCEPTION = CTRUSER_INSERTUSER + EXCEPTION,
        CTRUSER_INSERTUSER_SUCCESS = CTRUSER_INSERTUSER + SUCCESS,
        CTRUSER_LOGINUSER = CTRUSER + (YY * 11),
        CTRUSER_LOGINUSER_FAILURE_INITIAL = CTRUSER_LOGINUSER + 10,
        CTRUSER_LOGINUSER_FAILURE_INVALID_USERNAME = CTRUSER_LOGINUSER + 11,
        CTRUSER_LOGINUSER_FAILURE_INVALID_EMAIL = CTRUSER_LOGINUSER + 12,
        CTRUSER_LOGINUSER_FAILURE_INVALID_USERNAME_AND_EMAIL = CTRUSER_LOGINUSER + 13,
        CTRUSER_LOGINUSER_SUCCESS = CTRUSER_LOGINUSER + SUCCESS,
        //--------------------------------------------------

        //LANGUAGE
        //--------------------------------------------------
        //DBLANGUAGES
        DBLANGUAGES = XX * 12,
        DBLANGUAGES_INSERTLANGUAGE = DBLANGUAGES + (YY * 10),
        DBLANGUAGES_INSERTLANGUAGE_EXCEPTION = DBLANGUAGES_INSERTLANGUAGE + EXCEPTION,
        //CTRLANGUAGE
        CTRLANGUAGE = XX * 13,
        //--------------------------------------------------

        //TEXT
        //--------------------------------------------------
        //DBTEXTS
        DBTEXTS = XX * 14,
        DBTEXTS_INSERTTEXT = DBTEXTS + (YY * 10),
        DBTEXTS_INSERTTEXT_EXCEPTION = DBTEXTS_INSERTTEXT + EXCEPTION,
        //CTRTEXT
        CTRTEXT = XX * 15,
        CTRTEXT_INSERTTEXT = CTRTEXT + (YY * 10),
        CTRTEXT_INSERTTEXT_INVALID_TEXTDATA = CTRTEXT_INSERTTEXT + 10,
        CTRTEXT_INSERTTEXT_EXCEPTION = CTRTEXT_INSERTTEXT + EXCEPTION,
        //--------------------------------------------------

        //FILE
        //--------------------------------------------------
        //DBFILES
        DBFILES = XX * 16,
        DBFILES_INSERTFILE = DBFILES + (YY * 10),
        DBFILES_INSERTFILE_EXCEPTION = DBFILES_INSERTFILE + EXCEPTION,
        //CTRFILE
        CTRFILE = XX * 17,
        CTRFILE_INSERTFILE = CTRFILE + (YY * 10),
        CTRFILE_INSERTFILE_EXCEPTION = CTRFILE_INSERTFILE + EXCEPTION, 
        //--------------------------------------------------

        //UPLOAD
        //--------------------------------------------------
        //DBUPLOADS
        DBUPLOADS = XX * 18,
        DBUPLOADS_INSERTUPLOADTEXT = DBUPLOADS + (YY * 10),
        DBUPLOADS_INSERTUPLOADTEXT_EXCEPTION = DBUPLOADS_INSERTUPLOADTEXT + EXCEPTION,
        DBUPLOADS_INSERTUPLOADFILE = DBUPLOADS + (YY * 11),
        DBUPLOADS_INSERTUPLOADFILE_EXCEPTION = DBUPLOADS_INSERTUPLOADFILE + EXCEPTION,
        //CTRUPLOAD
        CTRUPLOAD = XX * 19,
        CTRUPLOAD_INSERTUPLOADTEXT = CTRUPLOAD + (YY * 10),
        CTRUPLOAD_INSERTUPLOADTEXT_FAILED_ONLYTEXT = CTRUPLOAD_INSERTUPLOADTEXT + 10,
        CTRUPLOAD_INSERTUPLOADTEXT_EXCEPTION = CTRUPLOAD_INSERTUPLOADTEXT + EXCEPTION,
        CTRUPLOAD_INSERTUPLOADFILE = CTRUPLOAD + (YY * 11),
        CTRUPLOAD_INSERTUPLOADFILE_FAILED_ONLYFILE = CTRUPLOAD_INSERTUPLOADFILE + 10,
        CTRUPLOAD_INSERTUPLOADFILE_EXCEPTION = CTRUPLOAD_INSERTUPLOADFILE + EXCEPTION,
        //--------------------------------------------------

        //JOB
        //--------------------------------------------------
        //DBUJOBS
        DBJOBS = XX * 20,
        DBJOBS_INSERTJOB = DBJOBS + (YY * 10),
        DBJOBS_INSERTJOB_EXCEPTION = DBJOBS_INSERTJOB + EXCEPTION, 
        //CTRJOB
        CTRJOB = XX * 21,
        //--------------------------------------------------

        //SUBMISSION
        //--------------------------------------------------
        //DBSUBMISSIONS
        DBSUBMISSIONS = XX * 22,
        DBSUBMISSIONS_INSERTSUBMISSION = DBSUBMISSIONS + (YY * 10),
        DBSUBMISSIONS_INSERTSUBMISSION_EXCEPTION = DBSUBMISSIONS_INSERTSUBMISSION + EXCEPTION, 
        //CTRSUBMISSION
        CTRSUBMISSION = XX * 23,
        //--------------------------------------------------
    }
}
