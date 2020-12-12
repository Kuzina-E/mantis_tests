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
    public class ProjectManagementHelper : HelperBase
    {

        public ProjectManagementHelper(ApplicationManager manager) : base(manager)
        {

        }

        public void Create(ProjectData project)
        {

            manager.MenageMenu.GoToProjectsPage();
            InitProjectCreation();
            FillProjectForm(project);
            SubmitProjectCreation();
            manager.MenageMenu.GoToManagePage();

        }

        public void Remove(ProjectData project)
        {

            manager.MenageMenu.GoToProjectsPage();
            GoToEditProjectPage(project.Name);
            InitProjectRemoving();
            ConfirmProjectRemoving();

        }


        private List<ProjectData> projectCache = null; 

        public List<ProjectData> GetProjectsList()
        {
            if (projectCache == null)
            {
                projectCache = new List<ProjectData>();

                manager.MenageMenu.GoToProjectsPage();

                if (IfProjectExist())
                {
                    ICollection<IWebElement> elements = driver.FindElements(By.XPath("//tbody//a[@href]"));

                    foreach (IWebElement element in elements)
                    {
                        projectCache.Add(new ProjectData(element.Text));
                    }
                }

            }


            return new List<ProjectData>(projectCache);
        }

        public void GoToEditProjectPage(string name)
        {

            driver.FindElement(By.XPath("//a[@href][.='" + name + "']")).Click();

        }




        public void FillProjectForm(ProjectData project)
        {
            Type(By.Id("project-name"), project.Name);
        }

        public void SubmitProjectCreation()
        {
            driver.FindElement(By.XPath("//input[@value='Add Project']")).Click();
            projectCache = null;

        }

        public void ConfirmProjectRemoving()
        {
            driver.FindElement(By.XPath("//input[@value='Delete Project']")).Click();
            projectCache = null;
        }

        public void InitProjectRemoving()
        {
            driver.FindElement(By.XPath("//input[@value='Delete Project']")).Click();
        }

     
        public void InitProjectCreation()
        {
            driver.FindElement(By.XPath("//button[.='Create New Project']")).Click();

        }

        public bool IfProjectExist()
        {
            manager.MenageMenu.GoToProjectsPage();
            return IsElementPresent(By.XPath("//tbody//a[@href]"));
        }
    }
}