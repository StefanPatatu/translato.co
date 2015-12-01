//author: futz
//helpers:
//last_checked: futz@20.11.2015

using Microsoft.VisualStudio.TestTools.UnitTesting;
using Translato.MODEL;

namespace Translato.Tests.MODELTests
{
    [TestClass]
    public class FileTests
    {
        [TestMethod]
        //LAYER_Class_NameOfTheMethod_TestedScenario_ExpectedBehaviour
        public void MODEL_File_FullConstructor_CreateFile_FileIsCreated()
        {
            //arrange
            int fileId = 1;

            //act
            File file_m1 = new File(
                fileId
                );

            //assert
            Assert.IsNotNull(file_m1, "file object is null");
            Assert.AreEqual(1, file_m1.fileId, "wrong fileId");
        }

        [TestMethod]
        //LAYER_Class_NameOfTheMethod_TestedScenario_ExpectedBehaviour
        public void MODEL_File_SetAndGetMethods_ModifyAllFieldsValues_AllValuesAreModified()
        {
            //arrange
            int fileId = 1;
            File file_m2 = new File(
                fileId
                );

            //act
            file_m2.fileId = 2;

            //assert
            Assert.IsNotNull(file_m2, "file object is null");
            Assert.AreEqual(2, file_m2.fileId, "fileId not changed");
        }
    }
}
