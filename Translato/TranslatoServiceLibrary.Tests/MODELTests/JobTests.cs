//author: adrian
//helpers: futz
//last_checked: futz@20.11.2015

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TranslatoServiceLibrary.MODEL;

namespace TranslatoServiceLibrary.Tests.MODELTests
{
    [TestClass]
    public class JobTests
    {
        [TestMethod]
        //LAYER_Class_NameOfTheMethod_TestedScenario_ExpectedBehaviour
        public void MODEL_Job_FullConstructor_CreateJob_JobIsCreated()
        {
            //arrange
            DateTimeOffset initDTO = DateTimeOffset.Now;

            int jobId = 1;
            string jobName = "Project1";
            DateTimeOffset dateCreated = initDTO;
            int durationInDays = 3;
            decimal reward = 100.99m;
            DateTimeOffset dateAwarded = initDTO.AddDays(3);
            Language languageFrom = new Language();
            Language languageTo = new Language();
            User user = new User();
            Upload upload = new Upload();

            //act
            Job job_m1 = new Job(
               jobId,
               jobName,
               dateCreated,
               durationInDays,
               reward,
               dateAwarded,
               languageFrom,
               languageTo,
               user,
               upload
               );

            //assert
            Assert.IsNotNull(job_m1, "job object is null");
            Assert.AreEqual(1, job_m1.jobId, "wrong jobId");
            Assert.AreEqual("Project1", job_m1.jobName, "wrong jobName");
            Assert.AreEqual(initDTO, job_m1.dateCreated, "wrong dateCreated");
            Assert.AreEqual(3, job_m1.durationInDays, "wrong durationInDays");
            Assert.AreEqual(100.99m, job_m1.reward, "wrong reward");
            Assert.AreEqual(initDTO.AddDays(3), job_m1.dateAwarded, "wrong dateAwarded");
            Assert.IsNotNull(job_m1.languageFrom, "job.languageFrom is null");
            Assert.IsNotNull(job_m1.languageTo, "job.languageTo is null");
            Assert.IsNotNull(job_m1.user, "job.user is null");
            Assert.IsNotNull(job_m1.upload, "job.upload is null");
        }

        [TestMethod]
        //LAYER_Class_NameOfTheMethod_TestedScenario_ExpectedBehaviour
        public void MODEL_Job_SetAndGetMethods_ModifyAllFieldsValues_AllValuesAreModified()
        {
            //arrange
            DateTimeOffset initDTO = DateTimeOffset.Now;

            int jobId = 1;
            string jobName = "Project1";
            DateTimeOffset dateCreated = initDTO;
            int durationInDays = 3;
            decimal reward = 100.99m;
            DateTimeOffset dateAwarded = initDTO.AddDays(3);
            Language languageFrom = new Language();
            Language languageTo = new Language();
            User user = new User();
            Upload upload = new Upload();
            Job job_m2 = new Job(
                jobId,
                jobName,
                dateCreated,
                durationInDays,
                reward,
                dateAwarded,
                languageFrom,
                languageTo,
                user,
                upload
                );

            //act
            Language languageFrom2 = new Language();
            Language languageTo2 = new Language();
            User user2 = new User();
            Upload upload2 = new Upload();

            job_m2.jobId = 2;
            job_m2.jobName = "Project2";
            job_m2.dateCreated = initDTO.AddMinutes(32);
            job_m2.durationInDays = 4;
            job_m2.reward = 150;
            job_m2.dateAwarded = initDTO.AddDays(1);
            job_m2.languageFrom = languageFrom2;
            job_m2.languageTo = languageTo2;
            job_m2.user = user2;
            job_m2.upload = upload2;

            //assert
            Assert.IsNotNull(job_m2, "job object is null");
            Assert.AreEqual(2, job_m2.jobId, "jobId not changed");
            Assert.AreEqual("Project2", job_m2.jobName, "jobName not changed");
            Assert.AreEqual(initDTO.AddMinutes(32), job_m2.dateCreated, "dateCreated not changed");
            Assert.AreEqual(4, job_m2.durationInDays, "durationInDays not changed");
            Assert.AreEqual(150, job_m2.reward, "reward not changed");
            Assert.AreEqual(initDTO.AddDays(1), job_m2.dateAwarded, "dateRewarded not changed");
            Assert.AreNotEqual(languageFrom, job_m2.languageFrom, "job.languageFrom not changed");
            Assert.AreNotEqual(languageTo, job_m2.languageTo, "job.languageTo not changed");
            Assert.AreNotEqual(user, job_m2.user, "job.user not changed");
            Assert.AreNotEqual(upload, job_m2.upload, "job.upload not changed");
        }
    }
}
