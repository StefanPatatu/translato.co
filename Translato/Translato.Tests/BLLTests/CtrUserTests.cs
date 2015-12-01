//author: futz
//helpers:
//last_checked: futz@20.11.2015

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Translato.MODEL;
using Translato.BLL;

namespace Translato.Tests.BLLTests
{
    [TestClass]
    public class CtrUserTests
    {
        [TestMethod]
        //LAYER_Class_NameOfTheMethod_TestedScenario_ExpectedBehaviour
        public void BLL_CtrUser_InsertUser_InsertUser_UserIsInserted()
        {
            //arrange
            int userId = 1;
            string userName = "frunza_adria1";
            string hashedPassword = "rsh45sh4g6gh4g65h4gf6h4fg6h54th";
            string firstName = "Adrian";
            string lastName = "Frunza";
            string email = "frunza.adrggian@email.com";
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
            CtrUser _CtrUser = new CtrUser();

            //act
            int result = _CtrUser.insertUser(user_m1);

            //assert
            Assert.AreEqual(1, result, "user not inserted");
        }
    }
}
