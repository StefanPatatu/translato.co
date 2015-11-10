using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WcfServiceLibrary.MODEL;


namespace WcfServiceLibrary.Tests.MODELTests
{
    [TestClass]
    public class LanguageTests
    {
        [TestMethod]
        //LAYER_Class_nameOfTheMethod_testedScenario_expectedBehaviour
        public void MODEL_Language_PublicConstructor_CreateLanguage_LanguageIsCreated()
        {
            //arrange
            int LanguageId = 1;
            string LanguageName = "Lithuanian";

            //act
            Language language_m1 = new Language(
                 LanguageId,
                 LanguageName);

            //assert
            Assert.IsNotNull(language_m1, "Language object is null");
            Assert.AreEqual(1, language_m1.LanguageId, "Wrong LanguageId");
            Assert.AreEqual("Lithuanian", language_m1.LanguageName, "Wrong LanguageName");
        }
        [TestMethod]
        //LAYER_Class_nameOfTheMethod_testedScenario_expectedBehaviour
        public void MODEL_Language_SetAndGetMethods_ModifyAllFieldsValues_AllValuesAreModified()
        {
            //arrange
            int LanguageId = 1;
            string LanguageName = "Lithuanian";
            Language language_m2 = new Language(
                LanguageId,
                LanguageName);

            //act
            language_m2.LanguageId = 2;
            language_m2.LanguageName = "not.Lithuanian";

            //assert
            Assert.IsNotNull(language_m2, "Language object is null");
            Assert.AreEqual(2, language_m2.LanguageId, "LanguageId not changed");
            Assert.AreEqual("not.Lithuanian", language_m2.LanguageName, "LanguageName not changed");
        }
    }
}