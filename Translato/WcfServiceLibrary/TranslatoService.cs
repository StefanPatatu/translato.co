﻿//author: futz
//helpers:
//last_cheked: futz@20.11.2015

using WcfServiceLibrary.MODEL;
using WcfServiceLibrary.BLL;

namespace WcfServiceLibrary
{
    public class TranslatoService : ITranslatoService
    {
        public int insertUser(User user)
        {
            CtrUser _ctrUser = new CtrUser();
            return _ctrUser.insertUser(user);
        }
    }
}