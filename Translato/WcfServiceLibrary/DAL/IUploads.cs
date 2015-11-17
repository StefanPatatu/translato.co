using WcfServiceLibrary.MODEL;

namespace WcfServiceLibrary.DAL
{
    public interface IUploads
    {
        int insertUploadText(Upload upload);
        int insertUploadFile(Upload upload);
    }
}
