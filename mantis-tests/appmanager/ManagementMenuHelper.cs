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
    public class ManagementMenuHelper : HelperBase
    {

        private string baseURL;

        public ManagementMenuHelper(ApplicationManager manager, string baseURL) : base(manager)
        {
            this.baseURL = baseURL;
        }

    

        public void GoToProjectsPage()
        {
            if (driver.Url == baseURL + "/manage_proj_page.php" && IsElementPresent(By.XPath("//button[.='Create New Project']")))
            {
                return;
            }

            GoToManagePage();

            driver.FindElement(By.XPath("//a[.='Manage Projects']")).Click();

        }

        public void GoToManagePage()
        {
            if (driver.Url == baseURL + "/manage_overview_page.php")
            {
                return;
            }

            driver.Navigate().GoToUrl(baseURL + "/manage_overview_page.php");

        }
    }
}