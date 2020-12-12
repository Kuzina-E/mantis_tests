using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace mantis_tests

{

    public class LoginHelper : HelperBase

    {

        public LoginHelper(ApplicationManager manager) : base(manager)
        {
        }

        public void Login(AccountData account)
        {
            if (IsLoggedIn())
            {
                if (IsLoggedIn(account))
                {
                    return;
                }
                Logout();
            }

            Type(By.Name("username"), account.Name);
            driver.FindElement(By.XPath("//input[@value='Login']")).Click();

            Type(By.Name("password"), account.Password);
            driver.FindElement(By.XPath("//input[@value='Login']")).Click();
        }

        public bool IsLoggedIn(AccountData account)
        {
            return IsLoggedIn()
                && GetLoggetUserName() == account.Name;
        }

        public bool IsLoggedIn()
        {
            return IsElementPresent(By.CssSelector("span.user-info"));
        }

        public void Logout()
        {
            if (IsLoggedIn())
            {

                driver.FindElements(By.CssSelector("a.dropdown-toggle"))[1].Click();

                driver.FindElement(By.XPath("//a[text()=' Logout']")).Click();

            }

        }
        private string GetLoggetUserName()
        {
            return driver.FindElement(By.CssSelector("span.user-info")).Text;

        }
    }
}