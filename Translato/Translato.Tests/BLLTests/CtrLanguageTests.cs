//author: adrian
//helpers:
//last_checked:

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Translato.MODEL;
using Translato.BLL;

namespace Translato.Tests.BLLTests
{
    [TestClass]
    public class CtrLanguageTests
    {
        [TestMethod]
        //LAYER_Class_NameOfTheMethod_TestedScenario_ExpectedBehaviour
        public void BLL_CtrLanguage_InsertLanguage_InsertLanguage_LanguageIsInserted()
        {
            //arrange
            int languageId = 1;
            string languageName = "Spanishtt";

            Language language_m1 = new Language(
                languageId,
                languageName
                );
            CtrLanguage _CtrLanguage = new CtrLanguage();

            //act
            int result = _CtrLanguage.insertLanguage(language_m1);

            //assert
            Assert.AreEqual(1, result, "language not inserted");
        }
    }
}
