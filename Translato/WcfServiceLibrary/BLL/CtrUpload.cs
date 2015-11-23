//author: adrian
//helpers:
//last_checked:

using System;
using WcfServiceLibrary.MODEL;
using WcfServiceLibrary.DAL;

namespace WcfServiceLibrary.BLL
{
    public class CtrUpload
    {
        //returns 1 if successful
        //returns 0 if failure of any kind
        public int insertUploadText(Upload upload)
        {
            int result = -1;

            if ( result == 0 || 
                !upload.file.Equals(null) ||
                upload.text.Equals(null)
               )
            { result = 0; }

            if (result != 0)//safe to proceed
            {
                IUploads _DbUploads = new DbUploads();

                result = _DbUploads.insertUploadText(upload);
            }
            else
            {
                result = 0;
            }
            return result;
        }
        public int insertUploadFile(Upload upload)
        {
            int result = -1;

            if (result == 0 ||
                 !upload.text.Equals(null) ||
                 upload.file.Equals(null)
               )
            { result = 0; }

            if (result != 0)//safe to proceed
            {
                IUploads _DbUploads = new DbUploads();

                result = _DbUploads.insertUploadFile(upload);
            }
            else
            {
                result = 0;
            }
            return result;
        }
    }
}
