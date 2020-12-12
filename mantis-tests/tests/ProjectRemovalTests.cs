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
            if (!app.Projects.IfProjectExist())
            {
                app.Projects.Create(new ProjectData("Test"));
            }

            List<ProjectData> oldList = app.Projects.GetProjectsList();
            ProjectData toRemove = oldList[0];

            app.Projects.Remove(toRemove);

            List<ProjectData> newList = app.Projects.GetProjectsList();
            oldList.RemoveAt(0);
            oldList.Sort();
            newList.Sort();

            Assert.AreEqual(oldList, newList);
        }
    }
}