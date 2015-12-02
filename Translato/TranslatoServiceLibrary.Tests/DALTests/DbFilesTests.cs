//author: adrian
//helpers: futz
//last_checked: futz@20.11.2015

using Microsoft.VisualStudio.TestTools.UnitTesting;
using TranslatoServiceLibrary.MODEL;
using TranslatoServiceLibrary.DAL;

namespace TranslatoServiceLibrary.Tests.DALTests
{
    [TestClass]
    public class DbFilesTests
    {
        [TestMethod]
        //LAYER_Class_NameOfTheMethod_TestedScenario_ExpectedBehaviour
        public void DAL_IFile_InsertFile_InsertFile_FileIsInserted()
        {
            //arrange
            int fileId = 5;
            File file_m1 = new File(
                fileId
                );
            IFiles _DbFiles = new DbFiles();

            //act
            int result = _DbFiles.insertFile(file_m1);

            //assert
            Assert.AreEqual(1, result, "file not inserted into the database");
        }
    }
}
