//author: futz
//helpers:
//last_checked: futz@20.11.2015

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WcfServiceLibrary.MODEL;
using WcfServiceLibrary.DAL;

namespace WcfServiceLibrary.Tests.DALTests
{
    [TestClass]
    public class DbUsersTests
    {
        [TestMethod]
        //LAYER_Class_NameOfTheMethod_TestedScenario_ExpectedBehaviour
        public void DAL_IUser_InsertUser_InsertUser_UserIsInserted()
        {
            //arrange
            int userId = 1;
            string userName = "frunzaadrian";
            string hashedPassword = "rsh45sh46gh4g65h4gf6h4fg6h54th";
            string firstName = "Adrian";
            string lastName = "Frunza";
            string email = "frunza.adrian@email.com";
            bool newsletterOptOut = false;
            DateTimeOffset createdOn = DateTimeOffset.Now;
            User user_m1 = new User(
                userId,
                userName,
                hashedPassword,
                firstName,
                lastName,
                email,
                newsletterOptOut,
                createdOn
                );
            IUsers _DbUsers = new DbUsers();

            //act
            int result = _DbUsers.insertUser(user_m1);

            //assert
            Assert.AreEqual(1, result, "user not inserted into the database");
        }
    }
}
