//author: adrian
//helpers:
//last_checked:

using System;
using System.Transactions;
using TranslatoServiceLibrary.MODEL;
using TranslatoServiceLibrary.DAL;

namespace TranslatoServiceLibrary.BLL
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

                try
                {
                    using (var trScope = TransactionScopeBuilder.CreateSerializable())
                    {
                        result = _DbUploads.insertUploadText(upload);

                        trScope.Complete();
                    }
                }
                catch (TransactionAbortedException taEx)
                {
                    DEBUG.Log.Add(taEx.ToString());
                }
                catch (ApplicationException aEx)
                {
                    DEBUG.Log.Add(aEx.ToString());
                }
                catch (Exception ex)
                {
                    DEBUG.Log.Add(ex.ToString());
                }
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

                try
                {
                    using (var trScope = TransactionScopeBuilder.CreateSerializable())
                    {
                        result = _DbUploads.insertUploadFile(upload);

                        trScope.Complete();
                    }
                }
                catch (TransactionAbortedException taEx)
                {
                    DEBUG.Log.Add(taEx.ToString());
                }
                catch (ApplicationException aEx)
                {
                    DEBUG.Log.Add(aEx.ToString());
                }
                catch (Exception ex)
                {
                    DEBUG.Log.Add(ex.ToString());
                }
            }
            else
            {
                result = 0;
            }
            return result;
        }
    }
}
