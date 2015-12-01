//author: kristis133
//helpers:
//last_checked: futz@20.11.2015

using Microsoft.VisualStudio.TestTools.UnitTesting;
using Translato.MODEL;

namespace Translato.Tests.MODELTests
{
    [TestClass]
    public class LanguageTests
    {
        [TestMethod]
        //LAYER_Class_NameOfTheMethod_TestedScenario_ExpectedBehaviour
        public void MODEL_Language_FullConstructor_CreateLanguage_LanguageIsCreated()
        {
            //arrange
            int languageId = 1;
            string languageName = "Lithuanian";

            //act
            Language language_m1 = new Language(
                 languageId,
                 languageName
                 );

            //assert
            Assert.IsNotNull(language_m1, "language object is null");
            Assert.AreEqual(1, language_m1.languageId, "wrong languageId");
            Assert.AreEqual("Lithuanian", language_m1.languageName, "wrong languageName");
        }

        [TestMethod]
        //LAYER_Class_NameOfTheMethod_TestedScenario_ExpectedBehaviour
        public void MODEL_Language_SetAndGetMethods_ModifyAllFieldsValues_AllValuesAreModified()
        {
            //arrange
            int languageId = 1;
            string languageName = "Lithuanian";
            Language language_m2 = new Language(
                languageId,
                languageName
                );

            //act
            language_m2.languageId = 2;
            language_m2.languageName = "Romanian";

            //assert
            Assert.IsNotNull(language_m2, "language object is null");
            Assert.AreEqual(2, language_m2.languageId, "languageId not changed");
            Assert.AreEqual("Romanian", language_m2.languageName, "languageName not changed");
        }
    }
}
