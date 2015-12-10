//author: futz
//helpers:
//last_checked: futz@10.12.2015

using TranslatoServiceLibrary.MODEL;

namespace TranslatoServiceLibrary.DAL
{
    internal interface IUsers
    {
        //returns [int >= TRANSLATO_DATABASE_SEED] if successful
        //returns [int < TRANSLATO_DATABASE_SEED] if not
        int insertUser(User user);

        //returns "MODEL.User" object if successful
        //returns "null" if not
        User findUserByUserId(int userId);

        //returns "MODEL.User" object if successful
        //returns "null" if not
        User findUserByUserName(string userName);

        //returns "MODEL.User" object if successful
        //returns "null" if not
        User findUserByEmail(string email);
    }
}
