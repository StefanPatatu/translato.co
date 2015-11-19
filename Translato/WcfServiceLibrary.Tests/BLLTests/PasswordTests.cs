using Microsoft.VisualStudio.TestTools.UnitTesting;
using WcfServiceLibrary.BLL;

//author: futz
//helpers:

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
            string HashedPasswordAndSalt1 = Password.HashPassword(password);
            string HashedPasswordAndSalt2 = Password.HashPassword(password);
            string HashedPasswordAndSalt3 = Password.HashPassword(password);
            string HashedPasswordAndSalt4 = Password.HashPassword(password);
            string HashedPasswordAndSalt5 = Password.HashPassword(password);

            //assert
            Assert.IsNotNull(HashedPasswordAndSalt1, "HashedPasswordAndSalt1 is null");
            Assert.IsNotNull(HashedPasswordAndSalt2, "HashedPasswordAndSalt2 is null");
            Assert.IsNotNull(HashedPasswordAndSalt3, "HashedPasswordAndSalt3 is null");
            Assert.IsNotNull(HashedPasswordAndSalt4, "HashedPasswordAndSalt4 is null");
            Assert.IsNotNull(HashedPasswordAndSalt5, "HashedPasswordAndSalt5 is null");
            Assert.AreNotEqual(HashedPasswordAndSalt1, HashedPasswordAndSalt2, "1 and 2 are the same");
            Assert.AreNotEqual(HashedPasswordAndSalt2, HashedPasswordAndSalt3, "2 and 3 are the same");
            Assert.AreNotEqual(HashedPasswordAndSalt3, HashedPasswordAndSalt4, "3 and 4 are the same");
            Assert.AreNotEqual(HashedPasswordAndSalt4, HashedPasswordAndSalt5, "4 and 5 are the same");
        }
        [TestMethod]
        //LAYER_Class_NameOfTheMethod_TestedScenario_ExpectedBehaviour
        public void BLL_Password_VerifyHashedPassword_VerifyValidHashedPassword_ReturnTRUE()
        {
            //arrange
            string password = "1234567890abcde";

            //act
            string HashedPasswordAndSalt1 = Password.HashPassword(password);
            string HashedPasswordAndSalt2 = Password.HashPassword(password);
            string HashedPasswordAndSalt3 = Password.HashPassword(password);
            string HashedPasswordAndSalt4 = Password.HashPassword(password);
            string HashedPasswordAndSalt5 = Password.HashPassword(password);
            bool verify1 = Password.VerifyHashedPassword(HashedPasswordAndSalt1, password);
            bool verify2 = Password.VerifyHashedPassword(HashedPasswordAndSalt2, password);
            bool verify3 = Password.VerifyHashedPassword(HashedPasswordAndSalt3, password);
            bool verify4 = Password.VerifyHashedPassword(HashedPasswordAndSalt4, password);
            bool verify5 = Password.VerifyHashedPassword(HashedPasswordAndSalt5, password);

            //assert
            Assert.IsTrue(verify1, "Verify1 failed");
            Assert.IsTrue(verify2, "Verify2 failed");
            Assert.IsTrue(verify3, "Verify3 failed");
            Assert.IsTrue(verify4, "Verify4 failed");
            Assert.IsTrue(verify5, "Verify5 failed");
        }
    }
}
