using Allure.Commons;
using AllureCSharpCommons;
using AllureCSharpCommons.Events;
using AventStack.ExtentReports;
using BoDi;
using Core.Base;
using Core.Config;
using Core.Helpers;
using OpenQA.Selenium;
using System;
using System.IO;
using System.Reflection;
using TechTalk.SpecFlow;

namespace Demo
{
    [Binding]
    public class InitializeTest : TestBase
    {
        static AllureCSharpCommons.Allure _lifecycle = AllureCSharpCommons.Allure.Lifecycle;
       static string SuiteUid = "RegressionPack";
        /// <summary>
        /// The object test base
        /// </summary>
        static TestBase objTestBase = new TestBase();

        /// <summary>
        /// The browser
        /// </summary>
        private static string browser = "Chrome";

        /// <summary>
        /// The test
        /// </summary>
        private ExtentTest _test;
        /// <summary>
        /// The object container1
        /// </summary>
        private readonly IObjectContainer _objectContainer1, _objectContainer2,_objectContainer3;


        /// <summary>
        /// Initializes a new instance of the <see cref="InitializeTest"/> class.
        /// </summary>
        /// <param name="objectContainer1">The object container1.</param>
        /// <param name="objectContainer2">The object container2.</param>
        public InitializeTest(IObjectContainer objectContainer1, IObjectContainer objectContainer2, IObjectContainer objectCOntainer3)
        {
            _objectContainer1 = objectContainer1;
            _objectContainer2 = objectContainer2;
            _objectContainer3 = objectCOntainer3;
        }


        /// <summary>
        /// Initials the set up.
        /// </summary>
        [BeforeTestRun]
        public static void InitialSetUp()
        {
            _lifecycle.Fire(new TestSuiteStartedEvent(SuiteUid, "Arithmetic Operations...."));
            if (Settings.Parallelizable == null)
            {
                ConfigReader.SetFrameworkSettings();
            }
            objTestBase.TestSetUp("LendingQB Automation");
            Environment.CurrentDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        }
        /// <summary>
        /// Creates the test set up.
        /// </summary>
        [BeforeScenario]
        public void CreateTestSetUp()
        {
            if (Settings.UserName == null)
            {
                ConfigReader.SetFrameworkSettings();
            }
            _driver = objTestBase.StartTestExecution(browser, _driver);
            _test = objTestBase.CreateExtentObjectParallel(browser, _test);
            _objectContainer1.RegisterInstanceAs<IWebDriver>(_driver);
            _objectContainer2.RegisterInstanceAs<ExtentTest>(_test);
            _objectContainer3.RegisterInstanceAs<AllureCSharpCommons.Allure>(_lifecycle);
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            objTestBase.NavigateToURL(_driver,_lifecycle);
           
            _lifecycle.Fire(new TestCaseStartedEvent(SuiteUid,ScenarioContext.Current.ScenarioInfo.Title));
        // _driver.AppLogin(Settings.UserName, Settings.Password);

    }


        /// <summary>
        /// Teardowns this instance.
        /// </summary>
        [AfterScenario]
        public void Teardown()
        {
            _lifecycle.Fire(new TestCaseFinishedEvent());
            DictionaryProperties.Details.Clear();
            objTestBase.StopReportParallel(_driver, _test);
            //AllureHackForScenarioOutlineTests();
        }

        /// <summary>
        /// Cleans up.
        /// </summary>
        [AfterTestRun]
        public static void CleanUp()
        {
            _lifecycle.Fire(new TestSuiteFinishedEvent(SuiteUid));
            objTestBase.CloseBrowser(browser);
            objTestBase.CloseCurrentDriverServer(browser);
            extent.Flush();
        }
        //private void AllureHackForScenarioOutlineTests()
        //{
        //    ScenarioContext.Current.TryGetValue(out TestResult testresult);
        //    _lifecycle.Fire(testresult.uuid, tc =>
        //    {
        //        tc.name = ScenarioContext.Current.ScenarioInfo.Title;
        //        tc.historyId = Guid.NewGuid().ToString();
        //    });
        //}
    }
}
