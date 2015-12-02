//author: adrian
//helpers:
//last_checked:

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WcfServiceLibrary.MODEL;
using WcfServiceLibrary.BLL;

namespace WcfServiceLibrary.Tests.BLLTests
{
    [TestClass]
    public class CtrFileTests
    {
        [TestMethod]
        //LAYER_Class_NameOfTheMethod_TestedScenario_ExpectedBehaviour
        public void BLL_CtrFile_InsertFile_InsertFile_FileIsInserted()
        {
            //arrange
            int fileId = 1;

            File file_m1 = new File(
                fileId
                );
            CtrFile _CtrFile = new CtrFile();

            //act
            int result = _CtrFile.insertFile(file_m1);

            //assert
            Assert.AreEqual(1, result, "file not inserted");
        }
    }
}
