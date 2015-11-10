using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WcfServiceLibrary.MODEL;

namespace WcfServiceLibrary.Tests.MODELTests
{
    [TestClass]
    public class UserTests
    {
        [TestMethod]
        //nameOfTheMethod_testedScenario_expectedBehaviour
        public void Constructor_CreateUser_UserIsCreated()
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
            User user = new User(
                UserId,
                UserName,
                HashedPassword,
                PasswordSalt,
                FirstName,
                LastName,
                Email,
                NewsletterOptOut);
        }
    }
}
