using Allure.Commons;
using AllureCSharpCommons.Events;
using AventStack.ExtentReports;
using Demo.Factory;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace Demo
{
    [Binding]
    public class ApplicationLoginSteps
    {
        /// <summary>
        /// The object factory
        /// </summary>
        private readonly ObjectFactory _objectFactory;

        /// <summary>
        /// The driver
        /// </summary>
        private readonly IWebDriver _driver;

        /// <summary>
        /// The test
        /// </summary>
        private readonly ExtentTest _test;
        /// <summary>
        /// The test
        /// </summary>
        private readonly AllureCSharpCommons.Allure _lifecycle;
        public ApplicationLoginSteps(IWebDriver driver, ExtentTest test, AllureCSharpCommons.Allure allureLifeCycle)
        {
            _driver = driver;
            _test = test;
            _lifecycle = allureLifeCycle;
            _objectFactory = new ObjectFactory();
        }
        [Given(@"Navigte to URL ""(.*)""")]
        public void GivenNavigteToURL(string url)
        {
         
        }

       
        [When(@"Input the credentials (.*) and (.*)")]
        public void WhenInputTheCredentialsAnd(string p0, string p1)
        {
            //_lifecycle.Fire(new StepStartedEvent("Value 1 : " + p0 + " & " + "Value 2 : " + p1));
            ScenarioContext.Current.Pending();
            //_lifecycle.Fire(new StepFinishedEvent());
        }

        [When(@"Click on ""(.*)""")]
        public void WhenClickOn(string p0)
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"Verify user get correct result")]
        public void ThenVerifyUserGetCorrectResult()
        {
            ScenarioContext.Current.Pending();
        }

    }
}
