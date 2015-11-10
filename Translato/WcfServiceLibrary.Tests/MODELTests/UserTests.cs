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
            int UserId = 1;
            string UserName = "frunza.adrian";
            string HashedPassword = "rsh45sh46gh4g65h4gf6h4fg6h54th";
            string PasswordSalt = "dg6dfg45d5sfgd5";
            string FirstName = "Adrian";
            string LastName = "Frunza";
            string Email = "frunza.adrian@email.com";
            bool NewsletterOptOut = false;

            //act
            User user_m1 = new User(
                UserId,
                UserName,
                HashedPassword,
                PasswordSalt,
                FirstName,
                LastName,
                Email,
                NewsletterOptOut);

            //assert
            Assert.IsNotNull(user_m1);
            Assert.AreEqual(1, user_m1.UserId, "Wrong UserId");
            Assert.AreEqual("frunza.adrian", user_m1.UserName, "Wrong UserName");
            Assert.AreEqual("rsh45sh46gh4g65h4gf6h4fg6h54th", user_m1.HashedPassword, "Wrong HashedPassword");
            Assert.AreEqual("dg6dfg45d5sfgd5", user_m1.PasswordSalt, "Wrong PasswordSalt");
            Assert.AreEqual("Adrian", user_m1.FirstName, "Wrong FirstName");
            Assert.AreEqual("Frunza", user_m1.LastName, "Wrong LastName");
            Assert.AreEqual("frunza.adrian@email.com", user_m1.Email, "Wrong Email");
            Assert.IsTrue(!user_m1.NewsletterOptOut,"Wrong NewsletterOptOut");
        }
        [TestMethod]
        //LAYER_Class_nameOfTheMethod_testedScenario_expectedBehaviour
        public void MODEL_User_SetAndGetMethods_ModifyAllFieldsValues_AllValuesAreModified()
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
            User user_m2 = new User(
                UserId,
                UserName,
                HashedPassword,
                PasswordSalt,
                FirstName,
                LastName,
                Email,
                NewsletterOptOut);

            //act
            user_m2.UserId = 2;
            user_m2.UserName = "not.frunza.adrian";
            user_m2.HashedPassword = "rsh45sh46gh4g65h4gf6h4fg6h54ti";
            user_m2.PasswordSalt = "dg6dfg45d5sfgd6";
            user_m2.FirstName = "Adriann";
            user_m2.LastName = "Frunzulita";
            user_m2.Email = "not.frunza.adrian@email.com";
            user_m2.NewsletterOptOut = true;

            //assert
            Assert.IsNotNull(user_m2);
            Assert.AreEqual(2, user_m2.UserId, "UserId not changed");
            Assert.AreEqual("not.frunza.adrian", user_m2.UserName, "UserName not changed");
            Assert.AreEqual("rsh45sh46gh4g65h4gf6h4fg6h54ti", user_m2.HashedPassword, "HashedPassword not changed");
            Assert.AreEqual("dg6dfg45d5sfgd6", user_m2.PasswordSalt, "PasswordSalt not changed");
            Assert.AreEqual("Adriann", user_m2.FirstName, "FirstName not changed");
            Assert.AreEqual("Frunzulita", user_m2.LastName, "LastName not changed");
            Assert.AreEqual("not.frunza.adrian@email.com", user_m2.Email, "Email not changed");
            Assert.IsTrue(user_m2.NewsletterOptOut, "NewsletterOptOut not changed");
        }
    }
}
