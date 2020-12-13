using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using System.IO;

namespace mantis_tests
{
    [TestFixture]
    public class ProjectCreationTests : AuthTestBase
    {
        [Test]
        public void ProjectCreationTest()
        {
            List<ProjectData> oldList = app.API.GetProjectList(admin);

            ProjectData project = new ProjectData() { Name = "New Project " + Guid.NewGuid() };


            app.Projects.Create(project);

            List<ProjectData> newList = app.API.GetProjectList(admin);
            oldList.Add(project);
            oldList.Sort();
            newList.Sort();

            Assert.AreEqual(oldList, newList);
            foreach (ProjectData p in newList)
            {
                System.Console.Out.WriteLine(p.Name);
            }

        }
    }

}