using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace mantis_tests 
{
    [TestFixture]
    public class AccountCreationTests : TestBase
    {
        [SetUp]
        public void SetUpConfig()
        {
            app.Ftp.BackUpFile("/config/config_inc.php");


            using (Stream localFile = File.Open("/config_inc.php", FileMode.Open))
            {
                app.Ftp.Upload("/config/config_inc.php", localFile);
            }
        }

        [Test]
        public void TestAccountRegistration()
        {
            AccountData account = new AccountData() {
                Name = "testuser6",
                Password = "password",
                Email = "testuser6@localhost.localdomain"
            };

            app.James.Delete(account);
            app.James.Add(account);


            app.Registration.Register(account);


        }

        [TearDown]

        public void restoreConfig()
        {
            app.Ftp.RestoreBackUpFile("/config/config_inc.php");
        }

    }
}
