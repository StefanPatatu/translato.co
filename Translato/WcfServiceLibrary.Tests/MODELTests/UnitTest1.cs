using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WcfServiceLibrary.MODEL;

//author: DarkSun
//helpers:

namespace WcfServiceLibrary.Tests.MODELTests
{
    [TestClass]
    public class SubmissionTests
    {
        [TestMethod]
        //LAYER_Class_nameOfTheMethod_testedScenario_expectedBehaviour
        public void MODEL_Submission_PublicConstructor_CreateSubmission_SubmissionIsCreated()
        {
            //arrange
            int SubmissionId = 7;
            DateTimeOffset DateSubmitted = DateTimeOffset.Now;
            bool IsAwarded = false;
            int UserId = 5;
            int FileId = 3;
            int JobId = 4;

            //act
            Submission submission_m1 = new Submission(
            SubmissionId,
            DateSubmitted,
            IsAwarded,
            UserId,
            FileId,
            JobId);

            //assert
            Assert.IsNotNull(submission_m1);
            Assert.AreEqual(7, submission_m1.SubmissionId, "SubbmissionId wrong");
            Assert.IsTrue(!submission_m1.IsAwarded, "IsAwarded wrong");
            Assert.AreEqual(5, submission_m1.UserId, "UserId wrong");
            Assert.AreEqual(3, submission_m1.FileId, "FileId Wrong");
            Assert.AreEqual(4, submission_m1.JobId, "JobId wrong");

        }
        [TestMethod]
        //LAYER_Class_nameOfTheMethod_testedScenario_expectedBehaviour

        public void MODEL_Submission_SetAndGetMethods_UpdateAllValues_AllValuesAreUpdated()
        {
            //arrange
            int SubmissionId = 7;
            DateTimeOffset DateSubmitted = DateTimeOffset.Now;
            bool IsAwarded = false;
            int UserId = 5;
            int FileId = 3;
            int JobId = 4;
            Submission submission_m1 = new Submission(
            SubmissionId,
            DateSubmitted,
            IsAwarded,
            UserId,
            FileId,
            JobId);

            //act 
            submission_m1.SubmissionId = 9;
            submission_m1.IsAwarded = true;
            submission_m1.UserId = 3;
            submission_m1.FileId = 8;
            submission_m1.JobId = 1;

            //assert
            Assert.IsNotNull(submission_m1);
            Assert.AreEqual(9, submission_m1.SubmissionId, "SubbmissionId wrong");
            Assert.IsTrue(submission_m1.IsAwarded, "IsAwarded wrong");
            Assert.AreEqual(3, submission_m1.UserId, "UserId wrong");
            Assert.AreEqual(8, submission_m1.FileId, "FileId Wrong");
            Assert.AreEqual(1, submission_m1.JobId, "JobId wrong");

        }
    }
}
