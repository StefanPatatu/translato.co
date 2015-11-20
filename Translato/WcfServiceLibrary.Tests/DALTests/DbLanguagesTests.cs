using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WcfServiceLibrary.MODEL;
using WcfServiceLibrary.DAL;

//author: adrian
//helpers:

namespace WcfServiceLibrary.Tests.DALTests
{
    [TestClass]
    public class DbLanguagesTests
    {
        [TestMethod]
        //LAYER_Class_NameOfTheMethod_TestedScenario_ExpectedBehaviour
        public void DAL_ILanguage_InsertLanguage_InsertLanguage_LanguageIsInserted()
        {
            //arrange
            int LanguageId = 1;
            string LanguageName = "Romana";
            
            Language language_m1 = new Language(
                LanguageId,
                LanguageName);
            ILanguages _DbLanguages = new DbLanguages();

            //act
            int result = _DbLanguages.insertLanguage(language_m1);

            //assert
            Assert.AreEqual(1, result);

        }
    }
}
