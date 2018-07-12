using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace Orangehrm.Pages
{
    public class Scenarios
    {
        public Scenarios()
        {
            PageFactory.InitElements(StepDefinitions.Scenarios.driver, this);
        }

        #region WebElements
        [FindsBy(How = How.Id, Using = "txtUsername")]
        private IWebElement fldUsername;

        [FindsBy(How = How.Id, Using = "txtPassword")]
        private IWebElement fldPassword;

        [FindsBy(How = How.Id, Using = "btnLogin")]
        private IWebElement btnLogin;

        [FindsBy(How = How.XPath, Using = "//span[contains(@class, 'left-menu-title') and text() = 'Admin']")]
        private IWebElement lmtAdmin;

        [FindsBy(How = How.Id, Using = "menu_admin_UserManagement")]
        private IWebElement lmtUserManagement;

        [FindsBy(How = How.XPath, Using = "//span[contains(@class, 'left-menu-title') and text() = 'Users']")]
        private IWebElement lmtUsers;

        [FindsBy(How = How.XPath, Using = "//a[@class='btn-floating btn-large waves-effect waves-light']")]
        private IWebElement btnAddUser;

        [FindsBy(How = How.Id, Using = "selectedEmployee_value")]
        private IWebElement fldAddEmployee;

        [FindsBy(How = How.Id, Using = "user_name")]
        private IWebElement fldAddUsername;

        [FindsBy(How = How.Id, Using = "password")]
        private IWebElement fldAddPassword;

        [FindsBy(How = How.Id, Using = "confirmpassword")]
        private IWebElement fldAddConfirmPassword;
        
        [FindsBy(How = How.Id, Using = "systemUserSaveBtn")]
        private IWebElement btnAddUserSave;

        [FindsBy(How = How.Id, Using = "account-job")]
        private IWebElement ttlAccountJob;

        [FindsBy(How = How.Id, Using = "logoutLink")]
        private IWebElement btnLogout;


        #endregion

        public void Login (Table table)
        {
            string user = table.Rows[0]["Username"].ToString();
            string password = table.Rows[0]["Password"].ToString();

            Debug.WriteLine("User - " + user);
            Debug.WriteLine("Password - " + password);

            fldUsername.Clear();
            fldPassword.Clear();
            fldUsername.SendKeys(user);
            fldPassword.SendKeys(password);
            btnLogin.Click();
            
        }

        public void CreateUser(Table table)
        {
            Guid id = Guid.NewGuid();
            Debug.WriteLine("id - " + id);

            ClassTemp.tempUsername = Convert.ToBase64String(Guid.NewGuid().ToByteArray());
            ClassTemp.tempPassword = Convert.ToBase64String(Guid.NewGuid().ToByteArray());

            lmtAdmin.Click();
            lmtUserManagement.Click();
            lmtUsers.Click();
            var wait = new WebDriverWait(StepDefinitions.Scenarios.driver, TimeSpan.FromSeconds(40));
            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//a[@class='btn-floating btn-large waves-effect waves-light']")));

            btnAddUser.Click();

            string employee = table.Rows[0]["Employee"].ToString();
            wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("selectedEmployee_value")));
            fldAddEmployee.SendKeys(employee);
            fldAddUsername.SendKeys(ClassTemp.tempUsername);
            fldAddPassword.SendKeys(ClassTemp.tempPassword);
            fldAddConfirmPassword.SendKeys(ClassTemp.tempPassword);

            btnAddUserSave.Click();
        }

        public void LogOut()
        {
            ttlAccountJob.Click();
            var wait = new WebDriverWait(StepDefinitions.Scenarios.driver, TimeSpan.FromSeconds(40));
            wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("logoutLink")));
            btnLogout.Click();
        }

        public void LoginAsNewUser()
        {
            fldUsername.Clear();
            fldPassword.Clear();
            fldUsername.SendKeys(ClassTemp.tempUsername);
            fldPassword.SendKeys(ClassTemp.tempPassword);
            btnLogin.Click();
        }
    }
}
