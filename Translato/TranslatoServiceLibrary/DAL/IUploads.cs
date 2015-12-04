//author: adrian
//helpers: futz
//last_checked: futz@04.12.2015

using TranslatoServiceLibrary.MODEL;

namespace TranslatoServiceLibrary.DAL
{
    internal interface IUploads
    {
        //returns
        //returns
        int insertUploadText(Upload upload);

        //returns
        //returns
        int insertUploadFile(Upload upload);
    }
}
