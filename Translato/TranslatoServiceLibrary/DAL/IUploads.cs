//author: adrian
//helpers: futz
//last_checked: futz@10.12.2015
//talked about with Alex

using TranslatoServiceLibrary.MODEL;

namespace TranslatoServiceLibrary.DAL
{
    internal interface IUploads
    {
        //returns [int >= TRANSLATO_DATABASE_SEED] if successful
        //returns [int < TRANSLATO_DATABASE_SEED] if not
        int insertUploadText(Upload upload);

        //returns [int >= TRANSLATO_DATABASE_SEED] if successful
        //returns [int < TRANSLATO_DATABASE_SEED] if not
        int insertUploadFile(Upload upload);

        //returns "MODEL.Upload" object if successful
        //returns "null" if not
        Upload findUploadByUploadId(int uploadId);

        //returns "MODEL.Upload" object if successful
        //returns "null" if not
        Upload findUploadByTextId(int textId);

        //returns "MODEL.Upload" object if successful
        //returns "null" if not
        Upload findUploadByFileId(int fileId);
    }
}
