//author: futz
//helpers:
//last_checked: futz@20.11.2015

using WcfServiceLibrary.MODEL;

namespace WcfServiceLibrary.DAL
{
    public interface IUsers
    {
        int insertUser(User user);
    }
}
