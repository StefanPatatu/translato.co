//author: adrian
//helpers: futz
//last_checked: futz@04.12.2015

using System;
using System.Transactions;
using TranslatoServiceLibrary.DAL;
using TranslatoServiceLibrary.MODEL;

namespace TranslatoServiceLibrary.BLL
{
    internal sealed class CtrFile
    {
        //returns "1" if successful
        //returns "0" if failure of any kind
        //todo@futz
        internal int insertFile(File file)
        {
            int result = -1;

           //validations to be added

            if (result != 0)//safe to proceed
            {
                IFiles _DbFiles = new DbFiles();

                try
                {
                    using (var trScope = TransactionScopeBuilder.CreateSerializable())
                    {
                        result = _DbFiles.insertFile(file);

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
