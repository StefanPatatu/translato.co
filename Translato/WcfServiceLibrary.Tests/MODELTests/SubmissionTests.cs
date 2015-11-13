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
            User user = new User(7, "He", "djasfh35ui47h", "asd3k345fs", "Kirin", "Harthorn", "KH@gmail.com", false);
            Upload upload = new Upload (2, "Text", new Text(2, "sdk"), null);
            Job job = new Job (9, "Sunday", 
                new DateTimeOffset(2012, 7, 12, 8, 34, 56, new TimeSpan(1, 0, 0)), 
                2, 
                12,
                new DateTimeOffset(2012, 7, 17, 3, 23, 12, new TimeSpan(1, 0, 0)), 
                new Language(5, "Lt"), 
                new Language (1, "En"), 
                new User(6, "Broken", "sljfue234a2d", "d35gdf4", "Halo", "Darlbloom", "HD@gmail.com", false), 
                new Upload(8, "File", null, new File(3)));

            //act
            Submission submission_m1 = new Submission(
                SubmissionId,
                DateSubmitted,
                IsAwarded,
                user,
                upload,
                job);

            //assert
            Assert.IsNotNull(submission_m1, "Submission object is null");
            Assert.AreEqual(7, submission_m1.SubmissionId, "Wrong SubmissionId");
            Assert.IsNotNull(submission_m1.DateSubmitted, "DateSubmitted is null");
            Assert.IsTrue(!submission_m1.IsAwarded, "Wrong IsAwarded");
            Assert.AreEqual(7, submission_m1.User.UserId, "Wrong User");
            Assert.AreEqual(2, submission_m1.Upload.UploadId, "Wrong Upload");
            Assert.AreEqual(9, submission_m1.Job.JobId, "Wrong Job");

        }
        [TestMethod]
        //LAYER_Class_nameOfTheMethod_testedScenario_expectedBehaviour
        public void MODEL_Submission_SetAndGetMethods_UpdateAllValues_AllValuesAreUpdated()
        {
            //arrange
            DateTimeOffset InitDateSubmitted = DateTimeOffset.Now;

            int SubmissionId = 7;
            DateTimeOffset DateSubmitted = DateTimeOffset.Now;
            bool IsAwarded = false;
            User user = new User(7, "He", "djasfh35ui47h", "asd3k345fs", "Kirin", "Harthorn", "KH@gmail.com", false);
            Upload upload = new Upload(2, "Text", new Text(2, "sdk"), null);
            Job job = new Job(9, "Sunday",
                new DateTimeOffset(2012, 7, 12, 8, 34, 56, new TimeSpan(1, 0, 0)),
                2,
                12,
                new DateTimeOffset(2012, 7, 17, 3, 23, 12, new TimeSpan(1, 0, 0)),
                new Language(5, "Lt"),
                new Language(1, "En"),
                new User(6, "Broken", "sljfue234a2d", "d35gdf4", "Halo", "Darlbloom", "HD@gmail.com", false),
                new Upload(8, "File", null, new File(3)));
            Submission submission_m2 = new Submission(
                SubmissionId,
                DateSubmitted,
                IsAwarded,
                user,
                upload,
                job);

            //act 
            submission_m2.SubmissionId = 9;
            submission_m2.DateSubmitted = submission_m2.DateSubmitted.AddMinutes(32);
            submission_m2.IsAwarded = true;
            submission_m2.User = new User(6, "Broken", "sljfue234a2d", "d35gdf4", "Halo", "Darlbloom", "HD@gmail.com", true);
            submission_m2.Upload = new Upload(4, "File", null, new File(3));
            submission_m2.Job = new Job(3, "Sunday",
                new DateTimeOffset(2012, 7, 12, 8, 34, 56, new TimeSpan(1, 0, 0)),
                2,
                12,
                new DateTimeOffset(2012, 7, 17, 3, 23, 12, new TimeSpan(1, 0, 0)),
                new Language(5, "Lt"),
                new Language(1, "En"),
                new User(7, "He", "djasfh35ui47h", "asd3k345fs", "Kirin", "Harthorn", "KH@gmail.com", false),
                new Upload(8, "File", null, new File(3))); ;

            //assert
            Assert.IsNotNull(submission_m2);
            Assert.AreEqual(9, submission_m2.SubmissionId, "SubbmissionId not changed");
            Assert.AreEqual(InitDateSubmitted.AddMinutes(32), submission_m2.DateSubmitted, "DateSubmitted not changed");
            Assert.IsTrue(submission_m2.IsAwarded, "IsAwarded not changed");
            Assert.AreEqual(6, submission_m2.User.UserId, "User not changed");
            Assert.AreEqual(4, submission_m2.Upload.UploadId, "Upload not changed");
            Assert.AreEqual(3, submission_m2.Job.JobId, "Job not changed");
        }
    }
}
