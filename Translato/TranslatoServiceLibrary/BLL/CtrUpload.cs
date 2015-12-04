//author: adrian
//helpers: futz
//last_checked: futz@04.12.2015

using System;
using System.Transactions;
using TranslatoServiceLibrary.DAL;
using TranslatoServiceLibrary.MODEL;

namespace TranslatoServiceLibrary.BLL
{
    internal sealed class CtrUpload
    {
        //returns "1" if successful
        //returns "0" if failure of any kind
        //todo@futz
        internal int insertUploadText(Upload upload)
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

        //returns "1" if successful
        //returns "0" if failure of any kind
        //todo@futz
        internal int insertUploadFile(Upload upload)
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
