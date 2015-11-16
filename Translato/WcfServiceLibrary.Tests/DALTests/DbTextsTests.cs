using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WcfServiceLibrary.MODEL;
using WcfServiceLibrary.DAL;

//author: adrian
//helpers:

namespace WcfServiceLibrary.Tests.DALTests
{
    [TestClass]
    public class DbTextsTests
    {
        [TestMethod]
        //LAYER_Class_nameOfTheMethod_testedScenario_expectedBehaviour
        public void DAL_IText_InsertText_InsertText_TextIsInserted()
        {
            //arrange
            int TextId = 1;
            string TextData = "Romana";

            Text text_m1 = new Text(
                TextId,
                TextData);
            ITexts _DbTexts = new DbTexts();

            //act
            int result = _DbTexts.insertText(text_m1);

            //assert
            Assert.AreEqual(1, result);

        }
    }
}
