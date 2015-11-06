using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WcfServiceLibrary.MODEL
{
    class Requester
    {
        public int RequesterId { get; set; }
        public int UserName { get; set; }
        public string HashedPassword { get; set; }
        public string PasswordSalt { get; set; }
    }
}
