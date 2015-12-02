//author: futz
//helpers:
//last_checked: futz@20.11.2015

using Microsoft.VisualStudio.TestTools.UnitTesting;
using WcfServiceLibrary.BLL;

namespace WcfServiceLibrary.Tests.BLLTests
{
    [TestClass]
    public class PasswordTests
    {
        [TestMethod]
        //LAYER_Class_NameOfTheMethod_TestedScenario_ExpectedBehaviour
        public void BLL_Password_HashPassword_HashPassword_HashedPasswordAndSaltReturned()
        {
            //arrange
            string password = "1234567890abcde";

            //act
            string hashedPasswordAndSalt1 = Password.hashPassword(password);
            string hashedPasswordAndSalt2 = Password.hashPassword(password);
            string hashedPasswordAndSalt3 = Password.hashPassword(password);
            string hashedPasswordAndSalt4 = Password.hashPassword(password);
            string hashedPasswordAndSalt5 = Password.hashPassword(password);

            //assert
            Assert.IsNotNull(hashedPasswordAndSalt1, "hashedPasswordAndSalt1 is null");
            Assert.IsNotNull(hashedPasswordAndSalt2, "hashedPasswordAndSalt2 is null");
            Assert.IsNotNull(hashedPasswordAndSalt3, "hashedPasswordAndSalt3 is null");
            Assert.IsNotNull(hashedPasswordAndSalt4, "hashedPasswordAndSalt4 is null");
            Assert.IsNotNull(hashedPasswordAndSalt5, "hashedPasswordAndSalt5 is null");
            Assert.AreNotEqual(hashedPasswordAndSalt1, hashedPasswordAndSalt2, "1 and 2 are the same");
            Assert.AreNotEqual(hashedPasswordAndSalt2, hashedPasswordAndSalt3, "2 and 3 are the same");
            Assert.AreNotEqual(hashedPasswordAndSalt3, hashedPasswordAndSalt4, "3 and 4 are the same");
            Assert.AreNotEqual(hashedPasswordAndSalt4, hashedPasswordAndSalt5, "4 and 5 are the same");
        }

        [TestMethod]
        //LAYER_Class_NameOfTheMethod_TestedScenario_ExpectedBehaviour
        public void BLL_Password_VerifyHashedPassword_VerifyValidHashedPassword_ReturnTRUE()
        {
            //arrange
            string password = "1234567890abcde";

            //act
            string hashedPasswordAndSalt1 = Password.hashPassword(password);
            string hashedPasswordAndSalt2 = Password.hashPassword(password);
            string hashedPasswordAndSalt3 = Password.hashPassword(password);
            string hashedPasswordAndSalt4 = Password.hashPassword(password);
            string hashedPasswordAndSalt5 = Password.hashPassword(password);
            bool verify1 = Password.verifyHashedPassword(hashedPasswordAndSalt1, password);
            bool verify2 = Password.verifyHashedPassword(hashedPasswordAndSalt2, password);
            bool verify3 = Password.verifyHashedPassword(hashedPasswordAndSalt3, password);
            bool verify4 = Password.verifyHashedPassword(hashedPasswordAndSalt4, password);
            bool verify5 = Password.verifyHashedPassword(hashedPasswordAndSalt5, password);

            //assert
            Assert.IsTrue(verify1, "verify1 failed");
            Assert.IsTrue(verify2, "verify2 failed");
            Assert.IsTrue(verify3, "verify3 failed");
            Assert.IsTrue(verify4, "verify4 failed");
            Assert.IsTrue(verify5, "verify5 failed");
        }
    }
}
