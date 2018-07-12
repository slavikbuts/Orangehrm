using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace Orangehrm.StepDefinitions
{
    [Binding]
    public class Scenarios
    {
        public static IWebDriver driver { get; set; }
        Pages.Scenarios pages = new Pages.Scenarios();

        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            driver = new FirefoxDriver();
            driver.Manage().Window.Maximize();
        }

        [AfterTestRun]
        public static void AfterTestRun()
        {
            driver.Close();
            driver.Quit();
        }

        [Given(@"I open ""(.*)""")]
        public void GivenIOpen(string url)
        {
            driver.Navigate().GoToUrl(url);
        }
        
        [Given(@"I login as Admin")]
        public void GivenILoginAsAdmin(Table table)
        {
            pages.Login(table);
        }

        [When(@"I add a new user into the system")]
        public void WhenIAddANewUserIntoTheSystem(Table table)
        {
            pages.CreateUser(table);
        }

        [Then(@"the new user can log into the system")]
        public void ThenTheNewUserCanLogIntoTheSystem()
        {
            pages.LogOut();
            pages.LoginAsNewUser();
        }

    }
}
