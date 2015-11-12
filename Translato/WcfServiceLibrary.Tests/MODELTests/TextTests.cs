using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WcfServiceLibrary.MODEL;

//author: kristis133
//helpers:

namespace WcfServiceLibrary.Tests.MODELTests
{
    [TestClass]
    public class TextTests
    {
        [TestMethod]
        //LAYER_Class_nameOfTheMethod_testedScenario_expectedBehaviour
        public void MODEL_Text_PublicConstructor_CreateText_TextIsCreated()
        {
            //arrange
            int TextId = 1;
            string TextData = "I like Potato Salad";

            //act
            Text text_m1 = new Text(
                 TextId,
                 TextData);

            //assert
            Assert.IsNotNull(text_m1, "Text object is null");
            Assert.AreEqual(1, text_m1.TextId, "Wrong TextId");
            Assert.AreEqual("I like Potato Salad", text_m1.TextData, "Wrong TextData");
        }
        [TestMethod]
        //LAYER_Class_nameOfTheMethod_testedScenario_expectedBehaviour
        public void MODEL_Text_SetAndGetMethods_ModifyAllFieldsValues_AllValuesAreModified()
        {
            //arrange
            int TextId = 1;
            string TextData = "I like potato salad";
            Text text_m2 = new Text(
                TextId,
                TextData);

            //act
            text_m2.TextId = 2;
            text_m2.TextData = "I don't like potato salad";

            //assert
            Assert.IsNotNull(text_m2, "Text object is null");
            Assert.AreEqual(2, text_m2.TextId, "TextId not changed");
            Assert.AreEqual("I don't like potato salad", text_m2.TextData, "TextData not changed");
        }
    }
}