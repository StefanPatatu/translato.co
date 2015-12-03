//author: futz
//helpers:
//last_checked: futz@03.12.2015

using TranslatoServiceLibrary.MODEL;

namespace TranslatoServiceLibrary.DAL
{
    public interface IUsers
    {
        //returns "1" if successful
        //returns "0" if not
        int insertUser(User user);

        //returns "MODEL.User" object if successful
        //returns "null" if not
        User findUserById(int userId);

        //returns "MODEL.User" object if successful
        //returns "null" if not
        User findUserByUserName(string userName);

        //returns "MODEL.User" object if successful
        //returns "null" if not
        User findUserByEmail(string email);
    }
}
