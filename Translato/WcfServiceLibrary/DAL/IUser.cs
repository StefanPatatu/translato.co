using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WcfServiceLibrary.MODEL;

namespace WcfServiceLibrary.DAL
{
    public interface IUser
    {
        int insertUser(User user);
    }
}
