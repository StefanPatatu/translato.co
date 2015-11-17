using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WcfServiceLibrary.MODEL;
using WcfServiceLibrary.DAL;

//author: adrian
//helpers:

namespace WcfServiceLibrary.Tests.DALTests
{
    [TestClass]
    public class DbUploadsTests
    {
        [TestMethod]
        //LAYER_Class_nameOfTheMethod_testedScenario_expectedBehaviour
        public void DAL_IUpload_InsertUpload_InsertUpload_UploadIsInserted()
        {
            //arrange
            int UploadId = 7;
          
            Text Text = new Text(8, "Another text to be transalted");
           // File File = new File(10);
            
                ITexts _DbTexts = new DbTexts();
                _DbTexts.insertText(Text);

          //  IFiles _DbFiles = new DbFiles();
            //_DbFiles.insertFile(File);



            Upload upload_m1 = new Upload(UploadId, Text, null);
            IUploads _DbUploads = new DbUploads();

            //act
            int result = _DbUploads.insertUploadText(upload_m1);

            //assert
            Assert.AreEqual(1, result);

        }
    }
}
