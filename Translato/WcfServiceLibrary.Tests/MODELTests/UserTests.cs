using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WcfServiceLibrary.MODEL;

//author: futz
//helpers:

namespace WcfServiceLibrary.Tests.MODELTests
{
    [TestClass]
    public class UserTests
    {
        [TestMethod]
        //LAYER_Class_nameOfTheMethod_testedScenario_expectedBehaviour
        public void MODEL_User_PublicConstructor_CreateUser_UserIsCreated()
        {
            //arrange
            DateTimeOffset initDTO = DateTimeOffset.Now;

            int UserId = 1;
            string UserName = "frunza.adrian";
            string HashedPassword = "rsh45sh46gh4g65h4gf6h4fg6h54th";
            string FirstName = "Adrian";
            string LastName = "Frunza";
            string Email = "frunza.adrian@email.com";
            bool NewsletterOptOut = false;
            DateTimeOffset CreatedOn = initDTO;

            //act
            User user_m1 = new User(
                UserId,
                UserName,
                HashedPassword,
                FirstName,
                LastName,
                Email,
                NewsletterOptOut,
                CreatedOn);

            //assert
            Assert.IsNotNull(user_m1, "User object is null");
            Assert.AreEqual(1, user_m1.UserId, "Wrong UserId");
            Assert.AreEqual("frunza.adrian", user_m1.UserName, "Wrong UserName");
            Assert.AreEqual("rsh45sh46gh4g65h4gf6h4fg6h54th", user_m1.HashedPassword, "Wrong HashedPassword");
            Assert.AreEqual("Adrian", user_m1.FirstName, "Wrong FirstName");
            Assert.AreEqual("Frunza", user_m1.LastName, "Wrong LastName");
            Assert.AreEqual("frunza.adrian@email.com", user_m1.Email, "Wrong Email");
            Assert.IsTrue(!user_m1.NewsletterOptOut,"Wrong NewsletterOptOut");
            Assert.AreEqual(initDTO, user_m1.CreatedOn, "Wrong CreatedOn");
        }
        [TestMethod]
        //LAYER_Class_nameOfTheMethod_testedScenario_expectedBehaviour
        public void MODEL_User_SetAndGetMethods_ModifyAllFieldsValues_AllValuesAreModified()
        {
            //arrange
            DateTimeOffset initDTO = DateTimeOffset.Now;

            int UserId = 1;
            string UserName = "frunza.adrian";
            string HashedPassword = "rsh45sh46gh4g65h4gf6h4fg6h54th";
            string FirstName = "Adrian";
            string LastName = "Frunza";
            string Email = "frunza.adrian@email.com";
            bool NewsletterOptOut = false;
            DateTimeOffset CreatedOn = initDTO;
            User user_m2 = new User(
                UserId,
                UserName,
                HashedPassword,
                FirstName,
                LastName,
                Email,
                NewsletterOptOut,
                CreatedOn);

            //act
            user_m2.UserId = 2;
            user_m2.UserName = "not.frunza.adrian";
            user_m2.HashedPassword = "rsh45sh46gh4g65h4gf6h4fg6h54ti";
            user_m2.FirstName = "Adriann";
            user_m2.LastName = "Frunzulita";
            user_m2.Email = "not.frunza.adrian@email.com";
            user_m2.NewsletterOptOut = true;
            user_m2.CreatedOn = initDTO.AddMinutes(32);

            //assert
            Assert.IsNotNull(user_m2, "User object is null");
            Assert.AreEqual(2, user_m2.UserId, "UserId not changed");
            Assert.AreEqual("not.frunza.adrian", user_m2.UserName, "UserName not changed");
            Assert.AreEqual("rsh45sh46gh4g65h4gf6h4fg6h54ti", user_m2.HashedPassword, "HashedPassword not changed");
            Assert.AreEqual("Adriann", user_m2.FirstName, "FirstName not changed");
            Assert.AreEqual("Frunzulita", user_m2.LastName, "LastName not changed");
            Assert.AreEqual("not.frunza.adrian@email.com", user_m2.Email, "Email not changed");
            Assert.IsTrue(user_m2.NewsletterOptOut, "NewsletterOptOut not changed");
            Assert.AreEqual(initDTO.AddMinutes(32), user_m2.CreatedOn, "CreatedOn not changed");
        }
    }
}
