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
    public class CtrTextTests
    {
        [TestMethod]
        //LAYER_Class_NameOfTheMethod_TestedScenario_ExpectedBehaviour
        public void BLL_CtrText_InsertText_InsertText_TextIsInserted()
        {
            //arrange
            int textId = 1;
            string textData = "Test text to be inserted";
            
            Text text_m1 = new Text(
                textId,
                textData
                );
            CtrText _CtrText = new CtrText();

            //act
            int result = _CtrText.insertText(text_m1);

            //assert
            Assert.AreEqual(1, result, "text not inserted");
        }
    }
}
