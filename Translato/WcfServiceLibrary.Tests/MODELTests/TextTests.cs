//author: kristis133
//helpers:
//last_checked: futz@20.11.2015

using Microsoft.VisualStudio.TestTools.UnitTesting;
using WcfServiceLibrary.MODEL;

namespace WcfServiceLibrary.Tests.MODELTests
{
    [TestClass]
    public class TextTests
    {
        [TestMethod]
        //LAYER_Class_NameOfTheMethod_TestedScenario_ExpectedBehaviour
        public void MODEL_Text_FullConstructor_CreateText_TextIsCreated()
        {
            //arrange
            int textId = 1;
            string textData = "I like Potato Salad";

            //act
            Text text_m1 = new Text(
                 textId,
                 textData
                 );

            //assert
            Assert.IsNotNull(text_m1, "text object is null");
            Assert.AreEqual(1, text_m1.textId, "wrong textId");
            Assert.AreEqual("I like Potato Salad", text_m1.textData, "wrong textData");
        }

        [TestMethod]
        //LAYER_Class_NameOfTheMethod_TestedScenario_ExpectedBehaviour
        public void MODEL_Text_SetAndGetMethods_ModifyAllFieldsValues_AllValuesAreModified()
        {
            //arrange
            int textId = 1;
            string textData = "I like potato salad";
            Text text_m2 = new Text(
                textId,
                textData
                );

            //act
            text_m2.textId = 2;
            text_m2.textData = "I don't like potato salad";

            //assert
            Assert.IsNotNull(text_m2, "text object is null");
            Assert.AreEqual(2, text_m2.textId, "textId not changed");
            Assert.AreEqual("I don't like potato salad", text_m2.textData, "textData not changed");
        }
    }
}
