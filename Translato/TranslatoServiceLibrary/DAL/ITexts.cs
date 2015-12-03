//author: adrian
//helpers: futz
//last_checked: futz@03.12.2015

using TranslatoServiceLibrary.MODEL;

namespace TranslatoServiceLibrary.DAL
{
    public interface ITexts
    {
        //returns "1" if successful
        //returns "0" if not
        int insertText(Text text);

        //returns "MODEL.Text" object if successful
        //returns "null" if not
        Text findTextById(int textId);
    }
}
