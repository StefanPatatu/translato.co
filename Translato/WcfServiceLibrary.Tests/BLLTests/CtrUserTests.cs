using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WcfServiceLibrary.MODEL;
using WcfServiceLibrary.BLL;

//author: futz
//helpers:

namespace WcfServiceLibrary.Tests.BLLTests
{
    [TestClass]
    public class CtrUserTests
    {
        [TestMethod]
        //LAYER_Class_nameOfTheMethod_testedScenario_expectedBehaviour
        public void BLL_IUser_InsertUser_InsertUser_UserIsInserted()
        {
            //arrange
            int UserId = 1;
            string UserName = "frunza_adrian";
            string HashedPassword = "rsh45sh46gh4g65h4gf6h4fg6h54th";
            string FirstName = "Adrian";
            string LastName = "Frunza";
            string Email = "frunza.adrian@email.com";
            bool NewsletterOptOut = false;
            DateTimeOffset CreatedOn = DateTimeOffset.Now;
            User user_m1 = new User(
                UserId,
                UserName,
                HashedPassword,
                FirstName,
                LastName,
                Email,
                NewsletterOptOut,
                CreatedOn);
            CtrUser _ctrUser = new CtrUser();

            //act
            int result = _ctrUser.insertUser(user_m1);

            //assert
            Assert.AreEqual(1, result);
        }
    }
}
