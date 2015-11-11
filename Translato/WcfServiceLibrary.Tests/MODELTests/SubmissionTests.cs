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
            Assert.IsNotNull(submission_m1, "Submission object is null");
            Assert.AreEqual(7, submission_m1.SubmissionId, "Wrong SubmissionId");
            Assert.IsNotNull(submission_m1.DateSubmitted, "DateSubmitted is null");
            Assert.IsTrue(!submission_m1.IsAwarded, "Wrong IsAwarded");
            Assert.AreEqual(5, submission_m1.UserId, "Wrong UserId");
            Assert.AreEqual(3, submission_m1.FileId, "Wrong FileId");
            Assert.AreEqual(4, submission_m1.JobId, "Wrong JobId");

        }
        [TestMethod]
        //LAYER_Class_nameOfTheMethod_testedScenario_expectedBehaviour
        public void MODEL_Submission_SetAndGetMethods_UpdateAllValues_AllValuesAreUpdated()
        {
            //arrange
            DateTimeOffset InitDateSubmitted = DateTimeOffset.Now;

            int SubmissionId = 7;
            DateTimeOffset DateSubmitted = InitDateSubmitted;
            bool IsAwarded = false;
            int UserId = 5;
            int FileId = 3;
            int JobId = 4;
            Submission submission_m2 = new Submission(
                SubmissionId,
                DateSubmitted,
                IsAwarded,
                UserId,
                FileId,
                JobId);

            //act 
            submission_m2.SubmissionId = 9;
            submission_m2.DateSubmitted = submission_m2.DateSubmitted.AddMinutes(32);
            submission_m2.IsAwarded = true;
            submission_m2.UserId = 3;
            submission_m2.FileId = 8;
            submission_m2.JobId = 1;

            //assert
            Assert.IsNotNull(submission_m2);
            Assert.AreEqual(9, submission_m2.SubmissionId, "SubbmissionId not changed");
            Assert.AreEqual(InitDateSubmitted.AddMinutes(32), submission_m2.DateSubmitted, "DateSubmitted not changed");
            Assert.IsTrue(submission_m2.IsAwarded, "IsAwarded not changed");
            Assert.AreEqual(3, submission_m2.UserId, "UserId not changed");
            Assert.AreEqual(8, submission_m2.FileId, "FileId not changed");
            Assert.AreEqual(1, submission_m2.JobId, "JobId not changed");
        }
    }
}
