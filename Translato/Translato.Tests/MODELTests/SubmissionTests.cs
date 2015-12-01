//author: DarkSun
//helpers: futz
//last_checked: futz@20.11.2015

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Translato.MODEL;

namespace Translato.Tests.MODELTests
{
    [TestClass]
    public class SubmissionTests
    {
        [TestMethod]
        //LAYER_Class_NameOfTheMethod_TestedScenario_ExpectedBehaviour
        public void MODEL_Submission_FullConstructor_CreateSubmission_SubmissionIsCreated()
        {
            //arrange
            DateTimeOffset initDTO = DateTimeOffset.Now;

            int submissionId = 7;
            DateTimeOffset dateSubmitted = initDTO;
            bool isAwarded = false;
            User user = new User();
            Upload upload = new Upload();
            Job job = new Job();

            //act
            Submission submission_m1 = new Submission(
                submissionId,
                dateSubmitted,
                isAwarded,
                user,
                upload,
                job
                );

            //assert
            Assert.IsNotNull(submission_m1, "submission object is null");
            Assert.AreEqual(7, submission_m1.submissionId, "wrong submissionId");
            Assert.AreEqual(initDTO, submission_m1.dateSubmitted, "wrong dateSubmitted");
            Assert.IsTrue(!submission_m1.isAwarded, "wrong isAwarded");
            Assert.IsNotNull(submission_m1.user, "submission.user is null");
            Assert.IsNotNull(submission_m1.upload, "submission.upload is null");
            Assert.IsNotNull(submission_m1.job, "submission.job is null");
        }

        [TestMethod]
        //LAYER_Class_NameOfTheMethod_TestedScenario_ExpectedBehaviour
        public void MODEL_Submission_SetAndGetMethods_ModifyAllFieldsValues_AllValuesAreModified()
        {
            //arrange
            DateTimeOffset initDTO = DateTimeOffset.Now;

            int submissionId = 7;
            DateTimeOffset dateSubmitted = initDTO;
            bool isAwarded = false;
            User user = new User();
            Upload upload = new Upload();
            Job job = new Job();
            Submission submission_m2 = new Submission(
                submissionId,
                dateSubmitted,
                isAwarded,
                user,
                upload,
                job
                );

            //act
            User user2 = new User();
            Upload upload2 = new Upload();
            Job job2 = new Job();

            submission_m2.submissionId = 9;
            submission_m2.dateSubmitted = initDTO.AddMinutes(32);
            submission_m2.isAwarded = true;
            submission_m2.user = user2;
            submission_m2.upload = upload2;
            submission_m2.job = job2; ;

            //assert
            Assert.IsNotNull(submission_m2, "submission object is null");
            Assert.AreEqual(9, submission_m2.submissionId, "subbmissionId not changed");
            Assert.AreEqual(initDTO.AddMinutes(32), submission_m2.dateSubmitted, "dateSubmitted not changed");
            Assert.IsTrue(submission_m2.isAwarded, "isAwarded not changed");
            Assert.AreNotEqual(user, submission_m2.user, "submission.user not changed");
            Assert.AreNotEqual(upload, submission_m2.upload, "submission.upload not canged");
            Assert.AreNotEqual(job, submission_m2.job, "submission.job not changed");
        }
    }
}
