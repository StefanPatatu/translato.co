////author: adrian
////helpers:

//using System;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using WcfServiceLibrary.MODEL;
//using WcfServiceLibrary.DAL;

//namespace WcfServiceLibrary.Tests.DALTests
//{
//    [TestClass]
//    public class DbJobsTests
//    {
//        [TestMethod]
//        //LAYER_Class_NameOfTheMethod_TestedScenario_ExpectedBehaviour
//        public void DAL_IJob_insertJob_insertJob_JobIsInserted()
//        {
//            //arrange
//            int JobId = 1;
//            string JobName = "Job1";
//            DateTimeOffset DateCreated = new DateTimeOffset(2008, 5, 1, 8, 6, 32,
//                                 new TimeSpan(1, 0, 0));
//            int DurationInDays = 3;
//            decimal Reward = 100;
//            DateTimeOffset DateAwarded = new DateTimeOffset(2008, 5, 1, 8, 6, 32,
//                                 new TimeSpan(1, 0, 0));

//            int LanguageFromId = 1;
//            string LanguageFromText = "Lithuanian";
//            int LanguageToId = 2;
//            string LanguageToText = "Romanian";
//            Language LanguageFrom = new Language(LanguageFromId, LanguageFromText);
//            Language LanguageTo = new Language(LanguageToId, LanguageToText);

//            User User = new User(
//                1,
//                "Adrian",
//                "dg6dfg45d5sfgd6",
//                "Adrian",
//                "Frunza",
//                "frunza.adrian@yahoo.com",
//                false);
//            Upload Upload = new Upload(
//                1,

//                new Text(1,
//                "text1"),
//                new File(1));
//            Job job_m1 = new Job(
//                JobId,
//                JobName,
//                DateCreated,
//                DurationInDays,
//                Reward,
//                DateAwarded,
//                LanguageFrom,
//                LanguageTo,
//                User,
//                Upload);
//            IJobs _DbJobs = new DbJobs();

//            //act
//            int result = _DbJobs.insertJob(job_m1);

//            //assert
//            Assert.AreEqual(1, result);

//        }
//    }
//}
