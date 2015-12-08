//author: adrian
//helpers: futz
//last_checked: futz@08.12.2015

using System;
using System.Transactions;
using TranslatoServiceLibrary.DAL;
using TranslatoServiceLibrary.MODEL;
using TranslatoServiceLibrary.X;

namespace TranslatoServiceLibrary.BLL
{
    internal sealed class CtrUpload
    {
        //returns [int >= TRANSLATO_DATABASE_SEED] if successful
        //returns [int < TRANSLATO_DATABASE_SEED] if not
        internal int insertUploadText(Upload upload)
        {
            int returnCode = (int)CODE.ZERO;
            int result = (int)CODE.MINUS_ONE;

            //validate only text
            if (
                result == (int)CODE.ZERO || 
                upload.text == null ||
                upload.file != null
               ) { returnCode = (int)CODE.CTRUPLOAD_INSERTUPLOADTEXT_FAILED_ONLYTEXT; result = (int)CODE.ZERO; }
            if (returnCode == (int)CODE.ZERO && result != (int)CODE.ZERO)//safe to proceed
            {
                upload.text = upload.text;
                upload.file = null;

                CtrText _CtrText = new CtrText();
                IUploads _DbUploads = new DbUploads();

                try
                {
                    using (var trScope = TransactionScopeBuilder.CreateSerializable())
                    {
                        returnCode = _CtrText.insertText(upload.text);
                        if (returnCode >= (int)CODE.TRANSLATO_DATABASE_SEED)//means text was inserted successfully
                        {
                            upload.text.textId = returnCode;
                            returnCode = _DbUploads.insertUploadText(upload);
                        }
                        else
                        {//means text failed to be inserted
                            trScope.Dispose();
                        }

                        trScope.Complete();
                        trScope.Dispose();
                    }
                }
                catch (TransactionAbortedException taEx)
                {
                    X.Log.Add(taEx.ToString());
                }
                catch (ApplicationException aEx)
                {
                    X.Log.Add(aEx.ToString());
                }
                catch (Exception ex)
                {
                    X.Log.Add(ex.ToString());
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
                    X.Log.Add(taEx.ToString());
                }
                catch (ApplicationException aEx)
                {
                    X.Log.Add(aEx.ToString());
                }
                catch (Exception ex)
                {
                    X.Log.Add(ex.ToString());
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
