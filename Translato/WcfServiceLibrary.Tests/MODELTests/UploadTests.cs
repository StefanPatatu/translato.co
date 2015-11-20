//author: DarkSun
//helpers: kool-kat, futz
//last_checked: futz@20.11.2015

using Microsoft.VisualStudio.TestTools.UnitTesting;
using WcfServiceLibrary.MODEL;

namespace WcfServiceLibrary.Tests.MODELTests
{
    [TestClass]
    public class UploadTests
    {
        [TestMethod]
        //LAYER_Class_NameOfTheMethod_TestedScenario_ExpectedBehaviour
        public void MODEL_Upload_FullConstructor_CreateTextUpload_TextUploadIsCreated()
        {
            //arrange
            int uploadId = 5;

            Text text = new Text();
            text.textId = 3;
            text.textData = "'morning";

            File file = null;

            //act
            Upload upload_m1 = new Upload(
                uploadId,
                text,
                file
                );

            //assert
            Assert.IsNotNull(upload_m1, "upload object is null");
            Assert.AreEqual(5, upload_m1.uploadId, "wrong uploadId");

            Assert.IsNotNull(upload_m1.text, "upload.text object is null");
            Assert.AreEqual(3, upload_m1.text.textId, "wrong upload.text.textId");
            Assert.AreEqual("'morning", upload_m1.text.textData, "wrong upload.text.textData");

            Assert.IsNull(upload_m1.file, "upload.file is NOT null");
        }

        [TestMethod]
        //LAYER_Class_NameOfTheMethod_TestedScenario_ExpectedBehaviour
        public void MODEL_Upload_FullConstructor_CreateFileUpload_FileUploadIsCreated()
        {
            //arrange
            int uploadId = 6;

            Text text = null;

            File file = new File();
            file.fileId = 2;

            //act
            Upload upload_m2 = new Upload(
                uploadId,
                text,
                file
                );

            //assert
            Assert.IsNotNull(upload_m2, "upload object is null");
            Assert.AreEqual(6, upload_m2.uploadId, "wrong uploadId");

            Assert.IsNull(upload_m2.text, "upload.text is NOT null");

            Assert.IsNotNull(upload_m2.file, "upload.file object is null");
            Assert.AreEqual(2, upload_m2.file.fileId, "wrong upload.file.fileId");            
        }
    }
}
