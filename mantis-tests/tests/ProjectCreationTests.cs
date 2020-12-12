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
            List<ProjectData> oldList = app.Projects.GetProjectsList();

            ProjectData project = new ProjectData() { Name = "New Project " + Guid.NewGuid() };


            app.Projects.Create(project);

            List<ProjectData> newList = app.Projects.GetProjectsList();
            oldList.Add(project);
            oldList.Sort();
            newList.Sort();

            Assert.AreEqual(oldList, newList);
        }
    }

}