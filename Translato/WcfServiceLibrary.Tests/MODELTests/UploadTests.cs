using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WcfServiceLibrary.MODEL;

//author: DarkSun
//helper: kool-kat

namespace WcfServiceLibrary.Tests.MODELTests
{
    [TestClass]
    public class UploadTests
    {
        [TestMethod]
        //LAYER_Class_nameOfTheMethod_testedScenario_expectedBehaviour
        public void MODEL_Upload_PublicConstructor_CreateUpload_UploadIsCreated()
        {
            //arrange
            int UploadId = 5;
            string Type = "Hey";
            Text text = new Text(3, "'morning");
            File file = new File(6);

            //act
            Upload upload_m1 = new Upload(
                UploadId,
                Type,
                text,
                file);

            //assert
            Assert.IsNotNull(upload_m1, "Upload object is null");
            Assert.AreEqual(5, upload_m1.UploadId, "Wrong UploadId");
            Assert.AreEqual("Hey", upload_m1.Type, "Wrong Type");
            Assert.IsNotNull(upload_m1.Text, "Text object is null");
            Assert.IsNotNull(upload_m1.File, "File bject is null");
                }
        [TestMethod]
        //LAYER_Class_nameOfTheMethod_testedScenario_expectedBehaviour
        public void MODEL_Upload_SetAndGetMethods_AttributesAreEdited_AllValuesUpdated ()
        {
            //arrange
            int UploadId = 5;
            string Type = "Hey";
            Text text = new Text(3, "'morning");
            File file = new File(6);
            Upload upload_m2 = new Upload(
                UploadId,
                Type,
                text,
                file);

            //act
            upload_m2.UploadId = 2;
            upload_m2.Type = "LoL";
            upload_m2.Text = new Text(2, "'evening");
            upload_m2.File = new File(5);

            //assert
            Assert.IsNotNull(upload_m2, "Upload object is null");
            Assert.AreEqual(2, upload_m2.UploadId, "UploadId not changed");
            Assert.AreEqual("LoL", upload_m2.Type, "Type not changed");
            Assert.AreEqual(2, upload_m2.Text.TextId, "TextId not changed");
            Assert.AreEqual("'evening", upload_m2.Text.TextData, "TextData not changed");
            Assert.AreEqual(5, upload_m2.File.FileId, "FileId not changed");
        }
    }
}
