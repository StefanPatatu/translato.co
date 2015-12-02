//author: futz
//helpers:
//last_checked: futz@20.11.2015

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WcfServiceLibrary.MODEL;

namespace WcfServiceLibrary.Tests.MODELTests
{
    [TestClass]
    public class UserTests
    {
        [TestMethod]
        //LAYER_Class_NameOfTheMethod_TestedScenario_ExpectedBehaviour
        public void MODEL_User_FullConstructor_CreateUser_UserIsCreated()
        {
            //arrange
            DateTimeOffset initDTO = DateTimeOffset.Now;

            int userId = 1;
            string userName = "frunza.adrian";
            string hashedPassword = "rsh45sh46gh4g65h4gf6h4fg6h54th";
            string firstName = "Adrian";
            string lastName = "Frunza";
            string email = "frunza.adrian@email.com";
            bool newsletterOptOut = false;
            DateTimeOffset createdOn = initDTO;

            //act
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

            //assert
            Assert.IsNotNull(user_m1, "user object is null");
            Assert.AreEqual(1, user_m1.userId, "wrong userId");
            Assert.AreEqual("frunza.adrian", user_m1.userName, "wrong userName");
            Assert.AreEqual("rsh45sh46gh4g65h4gf6h4fg6h54th", user_m1.hashedPassword, "wrong hashedPassword");
            Assert.AreEqual("Adrian", user_m1.firstName, "wrong firstName");
            Assert.AreEqual("Frunza", user_m1.lastName, "wrong lastName");
            Assert.AreEqual("frunza.adrian@email.com", user_m1.email, "wrong email");
            Assert.IsTrue(!user_m1.newsletterOptOut,"wrong newsletterOptOut");
            Assert.AreEqual(initDTO, user_m1.createdOn, "wrong createdOn");
        }

        [TestMethod]
        //LAYER_Class_NameOfTheMethod_TestedScenario_ExpectedBehaviour
        public void MODEL_User_SetAndGetMethods_ModifyAllFieldsValues_AllValuesAreModified()
        {
            //arrange
            DateTimeOffset initDTO = DateTimeOffset.Now;

            int userId = 1;
            string userName = "frunza.adrian";
            string hashedPassword = "rsh45sh46gh4g65h4gf6h4fg6h54th";
            string firstName = "Adrian";
            string lastName = "Frunza";
            string email = "frunza.adrian@email.com";
            bool newsletterOptOut = false;
            DateTimeOffset createdOn = initDTO;
            User user_m2 = new User(
                userId,
                userName,
                hashedPassword,
                firstName,
                lastName,
                email,
                newsletterOptOut,
                createdOn
                );

            //act
            user_m2.userId = 2;
            user_m2.userName = "not.frunza.adrian";
            user_m2.hashedPassword = "rsh45sh46gh4g65h4gf6h4fg6h54ti";
            user_m2.firstName = "Adriann";
            user_m2.lastName = "Frunzulita";
            user_m2.email = "not.frunza.adrian@email.com";
            user_m2.newsletterOptOut = true;
            user_m2.createdOn = initDTO.AddMinutes(32);

            //assert
            Assert.IsNotNull(user_m2, "user object is null");
            Assert.AreEqual(2, user_m2.userId, "userId not changed");
            Assert.AreEqual("not.frunza.adrian", user_m2.userName, "userName not changed");
            Assert.AreEqual("rsh45sh46gh4g65h4gf6h4fg6h54ti", user_m2.hashedPassword, "hashedPassword not changed");
            Assert.AreEqual("Adriann", user_m2.firstName, "firstName not changed");
            Assert.AreEqual("Frunzulita", user_m2.lastName, "lastName not changed");
            Assert.AreEqual("not.frunza.adrian@email.com", user_m2.email, "email not changed");
            Assert.IsTrue(user_m2.newsletterOptOut, "newsletterOptOut not changed");
            Assert.AreEqual(initDTO.AddMinutes(32), user_m2.createdOn, "createdOn not changed");
        }
    }
}
