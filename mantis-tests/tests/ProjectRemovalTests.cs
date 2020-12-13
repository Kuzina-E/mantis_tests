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
    public class ProjectRemovalTests : AuthTestBase
    {
        [Test]
        public void ProjectRemovalTest()
        {
            if (!app.API.IfProjectExist(admin))
            {
                app.API.CreateProject(admin, new ProjectData("Test"));
            }

            List<ProjectData> oldList = app.API.GetProjectList(admin);
            ProjectData toRemove = oldList[0];

            app.Projects.Remove(toRemove);

            List<ProjectData> newList = app.API.GetProjectList(admin);
            oldList.RemoveAt(0);
            oldList.Sort();
            newList.Sort();

            Assert.AreEqual(oldList, newList);
        }
    }
}