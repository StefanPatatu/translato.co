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
            int TextId = 4;
            int FileId = 8;

            //act
            Upload upload_m1 = new Upload(
                UploadId,
                Type,
                TextId,
                FileId);

            //assert
            Assert.IsNotNull(upload_m1, "Upload object is null");
            Assert.AreEqual(5, upload_m1.UploadId, "Wrong UploadId");
            Assert.AreEqual("Hey", upload_m1.Type, "Wrong Type");
            Assert.AreEqual(4, upload_m1.TextId, "Wrong TextId");
            Assert.AreEqual(8, upload_m1.FileId, "Wrong FileId");
                }
        [TestMethod]
        //LAYER_Class_nameOfTheMethod_testedScenario_expectedBehaviour
        public void MODEL_Upload_SetAndGetMethods_AttributesAreEdited_AllValuesUpdated ()
        {
            //arrange
            int UploadId = 5;
            string Type = "Hey";
            int TextId = 4;
            int FileId = 8;

            Upload upload_m2 = new Upload(
                UploadId,
                Type,
                TextId,
                FileId);

            //act
            upload_m2.UploadId = 2;
            upload_m2.Type = "LoL";
            upload_m2.TextId = 1;
            upload_m2.FileId = 5;

            //assert
            Assert.IsNotNull(upload_m2, "Upload object is null");
            Assert.AreEqual(2, upload_m2.UploadId, "UploadId not changed");
            Assert.AreEqual("LoL", upload_m2.Type, "Type not changed");
            Assert.AreEqual(1, upload_m2.TextId, "TextId not changed");
            Assert.AreEqual(5, upload_m2.FileId, "FileId not changed");
        }
    }
}
