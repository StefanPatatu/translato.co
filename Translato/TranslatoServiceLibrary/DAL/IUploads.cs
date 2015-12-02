//author: adrian
//helpers:
//last_checked: futz@20.11.2015

using TranslatoServiceLibrary.MODEL;

namespace TranslatoServiceLibrary.DAL
{
    public interface IUploads
    {
        int insertUploadText(Upload upload);
        int insertUploadFile(Upload upload);
    }
}
