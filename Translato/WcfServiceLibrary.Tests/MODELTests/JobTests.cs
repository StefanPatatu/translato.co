using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WcfServiceLibrary.MODEL;

//author: adrian
//helpers:

namespace WcfServiceLibrary.Tests.MODELTests
{
    [TestClass]
    public class JobTests
    {
        [TestMethod]
        //LAYER_Class_nameOfTheMethod_testedScenario_expectedBehaviour
        public void MODEL_Job_PublicConstructor_CreateUser_UserIsCreated()
        {
            //arrange
            int JobId = 1;
            string JobName = "Project1";
            DateTimeOffset DateCreated = new DateTimeOffset(2008, 5, 1, 8, 6, 32,
                                 new TimeSpan(1, 0, 0));
            int DurationInDays = 3;
            decimal Reward = 100;
            DateTimeOffset DateAwarded = new DateTimeOffset(2008, 5, 1, 8, 6, 32,
                                 new TimeSpan(1, 0, 0));
            Language LanguageFrom = new Language(1, "English");
            Language LanguageTo = new Language(2, "Roumanian");
            User User = new User(1, "Adrian", "rsh45sh46gh4g65h4gf6h4fg6h54ti", "dg6dfg45d5sfgd6", "Adrian", "Frunza", "frunza.adrian@yahoo.com", false);
            Upload Upload = new Upload(1, 1, new Text(1, "text1"), new File(1));

            //act
            public Job job_m1 = new Job(
                JobId,
                JobName,
                DateCreated,
                DurationInDays,
                Reward,
                DateAwarded,
                LanguageFrom,
                LanguageTo,
                User,
                Upload);

        //assert
        Assert.IsNotNull(job_m1, "job object is null");
            Assert.AreEqual(1, job_m1.JobId, "Wrong JobId");
            Assert.AreEqual( DateCreated, new DateTimeOffset(2008, 5, 1, 8, 6, 32,
                                 new TimeSpan(1, 0, 0)),"Wrong DateCreated"); 
            Assert.AreEqual(3, job_m1.DurationInDays, "Wrong DurationInDays");
            Assert.AreEqual(100, job_m1.Award, "Wrong Award");
            Assert.AreEqual(DateAwarded, new DateTimeOffset(2008, 5, 1, 8, 6, 32,
                                 new TimeSpan(1, 0, 0)), "Wrong DateAwarded");
            Assert.AreEqual(job_m1.LanguageFrom, new Language(1,"English"), "Wrong Language From");
            Assert.AreEqual(job_m1.LanguageTo, new Language(2,"Roumanian"), "Wrong Language To");
            Assert.AreEqual(job_m1.User, new User(1, "Adrian", "rsh45sh46gh4g65h4gf6h4fg6h54ti", "dg6dfg45d5sfgd6", "Adrian", "Frunza", "frunza.adrian@yahoo.com", false), "Wrong User");
            //Cannot test upload

        }
    [TestMethod]
    //LAYER_Class_nameOfTheMethod_testedScenario_expectedBehaviour
    public void MODEL_Job_SetAndGetMethods_ModifyAllFieldsValues_AllValuesAreModified()
    {
        //arrange
        int JobId = 1;
        string JobName = "Project1";
        DateTimeOffset DateCreated = new DateTimeOffset(2008, 5, 1, 8, 6, 32,
                             new TimeSpan(1, 0, 0));
        int DurationInDays = 3;
        decimal Reward = 100;
        DateTimeOffset DateAwarded = new DateTimeOffset(2008, 5, 1, 8, 6, 32,
                             new TimeSpan(1, 0, 0));
        Language LanguageFrom = new Language(1, "English");
        Language LanguageTo = new Language(2, "Roumanian");
        User User = new User(1, "Adrian", "rsh45sh46gh4g65h4gf6h4fg6h54ti", "dg6dfg45d5sfgd6", "Adrian", "Frunza", "frunza.adrian@yahoo.com", false);
            //I cannot create Upload object


    public Job job_m2 = new Job(
                JobId,
                JobName,
                DateCreated,
                DurationInDays,
                Reward,
                DateAwarded,
                LanguageFrom,
                LanguageTo,
                User,
                Upload);

    //act


    job_m2.JobId = 2;
        job_m2.JobName = "Project2";
        job_m2.DateCreated = new DateTimeOffset(2009, 5, 1, 8, 6, 32,
                                 new TimeSpan(1, 0, 0));
        job_m2.DurationInDays = 4;
        job_m2.Reward = 150;
        job_m2.DateAwarded  = new DateTimeOffset(2009, 5, 1, 8, 6, 32,
                                 new TimeSpan(1, 0, 0));
        job_m2.LanguageFrom = new Language(3,"French");
    job_m2.LanguageTo = new Language(4,"Deutch");
    job_m2.User = new User(1, "Adriana", "rsh45sh46gh4g65h4gf6h4fg6h54f", "dg6dfg45d5sfgd7", "Adriana", "Frunzaa", "afrunza.adrian@yahoo.com", true);
    //canot create upload 




    //assert
    Assert.IsNotNull(job_m2, "Job object is null");
            Assert.AreEqual(2, job_m2.JobId, "JobId not changed");
            Assert.AreEqual("Proect2", job_m2.JobName, "JobName not changed");
            Assert.AreEqual(new DateTimeOffset(2009, 5, 1, 8, 6, 32,
                                 new TimeSpan(1, 0, 0)), job_m2.DateCreated, "DateCreated not changed");
            Assert.AreEqual(4, job_m2.DurationInDays, "DurationInDays not changed");
            Assert.AreEqual(150, job_m2.Reward, "Reward not changed");
            Assert.AreEqual(new DateTimeOffset(2009, 5, 1, 8, 6, 32,
                                 new TimeSpan(1, 0, 0)), job_m2.DateAwarded, "DateCreated not changed");
            Assert.AreEqual(new Language(3,"French"), job_m2.LanguageFrom, "LanguageFrom not changed");
            Assert.AreEqual(new Language(3,"Deutch"), job_m2.LanguageTo, "LanguageTo not changed");
            Assert.AreEqual(new User(1, "Adriana", "rsh45sh46gh4g65h4gf6h4fg6h54f", "dg6dfg45d5sfgd7", "Adriana", "Frunzaa", "afrunza.adrian@yahoo.com", true),job_m2.User,"User not changed");
        //cannot test upload
        }
    }
}
