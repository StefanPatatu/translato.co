//author: futz
//helpers:
//last_checked: futz@20.11.2015

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TranslatoServiceLibrary.MODEL;
using TranslatoServiceLibrary.BLL;

namespace TranslatoServiceLibrary.Tests.BLLTests
{
    [TestClass]
    public class CtrUserTests
    {
        [TestMethod]
        //LAYER_Class_nameOfTheMethod_TestedScenario_ExpectedBehaviour
        public void BLL_CtrUser_insertUser_InsertUser_UserIsInserted()
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

        [TestMethod]
        //LAYER_Class_nameOfTheMethod_TestedScenario_ExpectedBehaviour
        public void BLL_CtrUser_findUserById_FindExistingUserById_UserObjectIsReturned()
        {
            //arrange
            int userId = 17; //change to a valid one before running the test
            CtrUser _CtrUser = new CtrUser();

            //act
            User user = _CtrUser.findUserById(userId);

            //assert
            Assert.IsNotNull(user);
        }
    }
}
