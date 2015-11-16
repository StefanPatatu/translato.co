using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WcfServiceLibrary.MODEL;
using WcfServiceLibrary.DAL;

//author: adrian
//helpers:

namespace WcfServiceLibrary.Tests.DALTests
{
    [TestClass]
    public class DbSubmissionsTests
    {
        [TestMethod]
        //LAYER_Class_nameOfTheMethod_testedScenario_expectedBehaviour
        public void DAL_ISubmission_InsertSubmission_InsertSubmission_SubmissionIsInserted()
        {
            //arrange
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

            
            Submission submission_m1 = new Submission(
                SubmissionId,
                DateSubmitted,
                IsAwarded,
                user,
                upload,
                job);


            ISubmissions _DbSubmissions = new DbSubmissions();

            //act
            int result = _DbSubmissions.insertSubmission(submission_m1);

            //assert
            Assert.AreEqual(1, result);

        }
    }
}
