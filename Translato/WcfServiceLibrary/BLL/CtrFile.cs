//author: adrian
//helpers:
//last_checked:

using System;
using WcfServiceLibrary.MODEL;
using WcfServiceLibrary.DAL;

namespace WcfServiceLibrary.BLL
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

                result = _DbFiles.insertFile(file);
            }
            else
            {
                result = 0;
            }
            return result;
        }
    }
}
