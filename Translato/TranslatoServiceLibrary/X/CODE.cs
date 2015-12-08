//author: futz
//helpers:
//last_cheked: futz@08.12.2015

namespace TranslatoServiceLibrary.X
{
    //format: XXYYZZ
    //XX = class code | YY = method code | ZZ = error code
    //XXYY99 = success
    internal enum CODE : int
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
        //--------------------------------------------------

        //USER
        //--------------------------------------------------
        //DBUSERS(XX) = 10
        //INSERTUSER(YY) = 10
        DBUSERS_INSERTUSER_EXCEPTION = 101088,
        //CTRUSER(XX) = 11
        //INSERTUSER(YY) = 10
        CTRUSER_INSERTUSER_INVALID_USERNAME = 111010,
        CTRUSER_INSERTUSER_INVALID_PASSWORD = 111011,
        CTRUSER_INSERTUSER_INVALID_FIRSTNAME = 111012,
        CTRUSER_INSERTUSER_INVALID_LASTNAME = 111013,
        CTRUSER_INSERTUSER_INVALID_EMAIL = 111014,
        CTRUSER_INSERTUSER_DAL_ERROR = 111077,
        CTRUSER_INSERTUSER_EXCEPTION = 111088,
        CTRUSER_INSERTUSER_SUCCESS = 111099,
        //LOGINUSER(YY) = 11
        CTRUSER_LOGINUSER_FAILURE = 111198,
        CTRUSER_LOGINUSER_SUCCESS = 111199,
        //--------------------------------------------------

        //LANGUAGE
        //--------------------------------------------------
        //DBLANGUAGES(XX) = 12
        //CTRLANGUAGE(XX) = 13
        //--------------------------------------------------

        //TEXT
        //--------------------------------------------------
        //DBTEXTS(XX) = 14
        //INSERTTEXT(YY) = 10
        DBTEXTS_INSERTTEXT_EXCEPTION = 141088,
        //CTRTEXT(XX) = 15
        //INSERTTEXT(YY) = 10
        CTRTEXT_INSERTTEXT_INVALID_TEXTDATA = 151010,
        CTRTEXT_INSERTTEXT_EXCEPTION = 151088,
        //--------------------------------------------------

        //FILE
        //--------------------------------------------------
        //DBFILES(XX) = 16
        //CTRFILE(XX) = 17
        //--------------------------------------------------

        //UPLOAD
        //--------------------------------------------------
        //DBUPLOADS(XX) = 18
        //INSERTUPLOADTEXT = 10
        DBUPLOADS_INSERTUPLOADTEXT_EXCEPTION = 181088,
        //INSERTUPLOADFILE = 11
        DBUPLOADS_INSERTUPLOADFILE_EXCEPTION = 181188,
        //CTRUPLOAD(XX) = 19
        //INSERTUPLOADTEXT = 10
        CTRUPLOAD_INSERTUPLOADTEXT_FAILED_ONLYTEXT = 191010,
        //--------------------------------------------------

        //JOB
        //--------------------------------------------------
        //DBUJOBS(XX) = 20 
        //CTRJOB(XX) = 21
        //--------------------------------------------------

        //SUBMISSION
        //--------------------------------------------------
        //DBSUBMISSIONS(XX) = 22 
        //CTRSUBMISSION(XX) = 23
        //--------------------------------------------------
    }
}
