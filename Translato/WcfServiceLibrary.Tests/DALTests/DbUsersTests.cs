using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WcfServiceLibrary.MODEL;
using WcfServiceLibrary.DAL;

//author: futz
//helpers:

namespace WcfServiceLibrary.Tests.DALTests
{
    [TestClass]
    public class DbUsersTests
    {
        [TestMethod]
        //LAYER_Class_nameOfTheMethod_testedScenario_expectedBehaviour
        public void DAL_IUser_InsertUser_InsertUser_UserIsInserted()
        {
            //arrange
            int UserId = 1;
            string UserName = "frunza.adrian";
            string HashedPassword = "rsh45sh46gh4g65h4gf6h4fg6h54th";
            string PasswordSalt = "dg6dfg45d5sfgd5";
            string FirstName = "Adrian";
            string LastName = "Frunza";
            string Email = "frunza.adrian@email.com";
            bool NewsletterOptOut = false;
            User user_m1 = new User(
                UserId,
                UserName,
                HashedPassword,
                PasswordSalt,
                FirstName,
                LastName,
                Email,
                NewsletterOptOut);
            IUsers _DbUsers = new DbUsers();

            //act
            int result = _DbUsers.insertUser(user_m1);

            //assert
            Assert.AreEqual(1, result);

        }
    }
}
