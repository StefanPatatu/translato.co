//author: adrian
//helpers: futz
//last_checked: futz@13.12.2015

using ENUM;
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
                returnCode != (int)CODE.ZERO ||
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
                    }
                }
                catch (TransactionAbortedException taEx)
                {
                    returnCode = (int)CODE.CTRUPLOAD_INSERTUPLOADTEXT_EXCEPTION;
                    Log.Add(taEx.ToString());
                }
                catch (ApplicationException aEx)
                {
                    returnCode = (int)CODE.CTRUPLOAD_INSERTUPLOADTEXT_EXCEPTION;
                    Log.Add(aEx.ToString());
                }
                catch (Exception ex)
                {
                    returnCode = (int)CODE.CTRUPLOAD_INSERTUPLOADTEXT_EXCEPTION;
                    Log.Add(ex.ToString());
                }
            }
            else { }
            return returnCode;
        }

        //returns [int >= TRANSLATO_DATABASE_SEED] if successful
        //returns [int < TRANSLATO_DATABASE_SEED] if not
        internal int insertUploadFile(Upload upload)
        {
            int returnCode = (int)CODE.ZERO;
            int result = (int)CODE.MINUS_ONE;

            //validate only file
            if (
                result == (int)CODE.ZERO ||
                returnCode != (int)CODE.ZERO ||
                upload.text != null ||
                upload.file == null
               ) { returnCode = (int)CODE.CTRUPLOAD_INSERTUPLOADFILE_FAILED_ONLYFILE; result = (int)CODE.ZERO; }
            if (returnCode == (int)CODE.ZERO && result != (int)CODE.ZERO)//safe to proceed
            {
                upload.text = null;
                upload.file = upload.file;

                CtrFile _CtrFile = new CtrFile();
                IUploads _DbUploads = new DbUploads();

                try
                {
                    using (var trScope = TransactionScopeBuilder.CreateSerializable())
                    {
                        returnCode = _CtrFile.insertFile(upload.file);
                        if (returnCode >= (int)CODE.TRANSLATO_DATABASE_SEED)//means file was inserted successfully
                        {
                            upload.file.fileId = returnCode;
                            returnCode = _DbUploads.insertUploadFile(upload);
                        }
                        else
                        {//means file failed to be inserted
                            trScope.Dispose();
                        }

                        trScope.Complete();
                    }
                }
                catch (TransactionAbortedException taEx)
                {
                    returnCode = (int)CODE.CTRUPLOAD_INSERTUPLOADFILE_EXCEPTION;
                    Log.Add(taEx.ToString());
                }
                catch (ApplicationException aEx)
                {
                    returnCode = (int)CODE.CTRUPLOAD_INSERTUPLOADFILE_EXCEPTION;
                    Log.Add(aEx.ToString());
                }
                catch (Exception ex)
                {
                    returnCode = (int)CODE.CTRUPLOAD_INSERTUPLOADFILE_EXCEPTION;
                    Log.Add(ex.ToString());
                }
            }
            else { }
            return returnCode;
        }

        //returns "MODEL.Upload" object if successful/found
        //returns "null" if not
        internal Upload findUploadByUploadId(int uploadId)
        {
            int result = (int)CODE.MINUS_ONE;
            Upload upload = null;

            //validate uploadId
            if (
                result == (int)CODE.ZERO ||
                string.IsNullOrWhiteSpace(uploadId.ToString()) ||
                !Validate.isAllNumbers(uploadId.ToString()) ||
                !Validate.integerIsBiggerThan(uploadId, (int)CODE.TRANSLATO_DATABASE_SEED - 1)
               ) { result = (int)CODE.ZERO; }
            if (result != (int)CODE.ZERO)//safe to proceed
            {
                IUploads _DbUploads = new DbUploads();

                try
                {
                    using (var trScope = TransactionScopeBuilder.CreateSerializable())
                    {
                        upload = _DbUploads.findUploadByUploadId(uploadId);

                        trScope.Complete();
                    }
                }
                catch (TransactionAbortedException taEx)
                {
                    result = (int)CODE.ZERO;
                    Log.Add(taEx.ToString());
                }
                catch (ApplicationException aEx)
                {
                    result = (int)CODE.ZERO;
                    Log.Add(aEx.ToString());
                }
                catch (Exception ex)
                {
                    result = (int)CODE.ZERO;
                    Log.Add(ex.ToString());
                }
            }
            else { result = (int)CODE.ZERO; }

            if (result == (int)CODE.ZERO || upload == null) { return null; }
            else { return upload; }
        }
    }
}
