//author: adrian
//helpers: futz
//last_checked: futz@13.12.2015
//talked about with Alex

using ENUM;
using System;
using System.Transactions;
using TranslatoServiceLibrary.DAL;
using TranslatoServiceLibrary.MODEL;
using TranslatoServiceLibrary.X;

namespace TranslatoServiceLibrary.BLL
{
    internal sealed class CtrFile
    {
        //returns [int >= TRANSLATO_DATABASE_SEED] if successful
        //returns [int < TRANSLATO_DATABASE_SEED] if not
        internal int insertFile(File file)
        {
            int returnCode = (int)CODE.ZERO;
            int result = (int)CODE.MINUS_ONE;

            //validate -> ToDo
            if (
                result == (int)CODE.ZERO ||
                returnCode != (int)CODE.ZERO
               ) { returnCode = (int)CODE.CTRTEXT_INSERTTEXT_INVALID_TEXTDATA; result = (int)CODE.ZERO; }
            if (returnCode == (int)CODE.ZERO && result != (int)CODE.ZERO)//safe to proceed
            {
                IFiles _DbFiles = new DbFiles();

                try
                {
                    using (var trScope = TransactionScopeBuilder.CreateSerializable())
                    {
                        returnCode = _DbFiles.insertFile(file);

                        trScope.Complete();
                    }
                }
                catch (TransactionAbortedException taEx)
                {
                    returnCode = (int)CODE.CTRFILE_INSERTFILE_EXCEPTION;
                    Log.Add(taEx.ToString());
                }
                catch (ApplicationException aEx)
                {
                    returnCode = (int)CODE.CTRFILE_INSERTFILE_EXCEPTION;
                    Log.Add(aEx.ToString());
                }
                catch (Exception ex)
                {
                    returnCode = (int)CODE.CTRFILE_INSERTFILE_EXCEPTION;
                    Log.Add(ex.ToString());
                }
            }
            else { }
            return returnCode;
        }
    }
}
