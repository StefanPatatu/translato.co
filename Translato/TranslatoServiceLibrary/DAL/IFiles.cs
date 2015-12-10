//author: adrian
//helpers: futz
//last_checked: futz@10.12.2015

using TranslatoServiceLibrary.MODEL;

namespace TranslatoServiceLibrary.DAL
{
    internal interface IFiles
    {
        //returns [int >= TRANSLATO_DATABASE_SEED] if successful
        //returns [int < TRANSLATO_DATABASE_SEED] if not
        int insertFile(File file);
    }
}
