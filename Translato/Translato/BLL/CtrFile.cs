//author: adrian
//helpers:
//last_checked:

using System;
using System.Transactions;
using Translato.MODEL;
using Translato.DAL;

namespace Translato.BLL
{
    public class CtrFile
    {
        //returns 1 if successful
        //returns 0 if failure of any kind
        public int insertFile(File file)
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
