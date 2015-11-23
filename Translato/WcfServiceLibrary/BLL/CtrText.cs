//author: adrian
//helpers:

using System;
using WcfServiceLibrary.MODEL;
using WcfServiceLibrary.DAL;

namespace WcfServiceLibrary.BLL
{
    public class CtrText
    {
        //returns 1 if successful
        //returns 0 if failure of any kind
        public int insertText(Text text)
        {
            int result = -1;

            //validate TextData
            if (
                result == 0 ||
                string.IsNullOrEmpty(text.textData) ||
                !Validate.hasMinLength(text.textData, 1) ||
                !Validate.hasMaxLength(text.textData, 40000)
                ) { result = 0; }

            if (result != 0)//safe to proceed
            {
                text.textData = text.textData;

                ITexts _DbTexts = new DbTexts();

                result = _DbTexts.insertText(text);
            }
            else
            {
                result = 0;
            }
            return result;
        }
    }
}
