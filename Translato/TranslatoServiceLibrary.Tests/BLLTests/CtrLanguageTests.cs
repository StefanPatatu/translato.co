//author: adrian
//helpers:
//last_checked:

using ENUM;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TranslatoServiceLibrary.MODEL;
using TranslatoServiceLibrary.BLL;

namespace TranslatoServiceLibrary.Tests.BLLTests
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
           
            Assert.IsTrue(result >= (int)ENUM.CODE.TRANSLATO_DATABASE_SEED,"language not inserted");
        }
    }
}
