using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mantis_tests 
{
    public class APIHelper : HelperBase
    {
        public APIHelper(ApplicationManager manager) : base(manager)
        {
           
        }


        public void CreateProject(AccountData account, ProjectData projectData)
        {
            Mantis.MantisConnectPortTypeClient client = new Mantis.MantisConnectPortTypeClient();
            Mantis.ProjectData project = new Mantis.ProjectData();
            project.name = projectData.Name;
            client.mc_project_add(account.Name, account.Password, project);
        }

        public List<ProjectData> GetProjectList(AccountData account)
        {
            Mantis.MantisConnectPortTypeClient client = new Mantis.MantisConnectPortTypeClient();
            Mantis.ProjectData[] projects = client.mc_projects_get_user_accessible(account.Name, account.Password);
            List<ProjectData> projectList = new List<ProjectData>();
            foreach (Mantis.ProjectData projectData in projects)
            {
                projectList.Add(new ProjectData()
                {
                    Name = projectData.name
         
                });
            }
            return projectList;
        }

        public bool IfProjectExist(AccountData account)
        {
            return (GetProjectList(account).Count() > 0);
        }
    }
}
