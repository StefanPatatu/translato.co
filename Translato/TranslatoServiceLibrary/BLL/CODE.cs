//author: futz
//helpers:
//last_cheked: futz@07.12.2015

namespace TranslatoServiceLibrary.BLL
{
    //format: XXYYZZ
    //XX = class code | YY = method code | ZZ = error code
    //XXYY99 = success
    internal enum CODE : int
    {
        //don't ask
        ZERO = 0, //fucking 0
        MINUS_ONE = -1, //fucking -1

        //GENERAL(XX) = 99
        //GENERAL(YY) = 99
        CLIENT_NOT_AUTHORIZED = 999910,

        //DB SEED
        TRANSLATO_DATABASE_SEED = 1000000,

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
        //LOGINUSER(YY) = 20
        CTRUSER_LOGINUSER_FAILURE = 112098,
        CTRUSER_LOGINUSER_SUCCESS = 112099,

        //DBTEXTS(XX) = 12
        //INSERTTEXT(YY) = 10
        DBTEXTS_INSERTTEXT_EXCEPTION = 121088,

        //CTRTEXT(XX) = 13
        //INSERTTEXT(YY) = 10
        CTRTEXT_INSERTTEXT_INVALID_TEXTDATA = 131010,
        CTRTEXT_INSERTTEXT_EXCEPTION = 131088,
    }
}
