//author: adrian
//helpers:
//last_checked: futz@20.11.2015

using Translato.MODEL;

namespace Translato.DAL
{
    public interface IUploads
    {
        int insertUploadText(Upload upload);
        int insertUploadFile(Upload upload);
    }
}
