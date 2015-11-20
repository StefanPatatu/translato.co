using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WcfServiceLibrary.MODEL;
using WcfServiceLibrary.DAL;

//author: adrian
//helpers:

namespace WcfServiceLibrary.Tests.DALTests
{
    [TestClass]
    public class DbFilesTests
    {
        [TestMethod]
        //LAYER_Class_NameOfTheMethod_TestedScenario_ExpectedBehaviour
        public void DAL_IFile_InsertFile_InsertFile_FileIsInserted()
        {
            //arrange
            int FileId = 5;
            

            File file_m1 = new File(
                FileId
                );
            IFiles _DbFiles = new DbFiles();

            //act
            int result = _DbFiles.insertFile(file_m1);

            //assert
            Assert.AreEqual(1, result);

        }
    }
}
