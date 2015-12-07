//author: adrian
//helpers: futz
//last_checked: futz@07.12.2015

using TranslatoServiceLibrary.MODEL;

namespace TranslatoServiceLibrary.DAL
{
    internal interface ITexts
    {
        //returns [int > TRANSLATO_DATABASE_SEED] if successful
        //returns [int < TRANSLATO_DATABASE_SEED] if not
        int insertText(Text text);

        //returns "MODEL.Text" object if successful
        //returns "null" if not
        Text findTextById(int textId);
    }
}
