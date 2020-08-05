using DevoxTestTask.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using DevoxTestTask.DataAccess.Models;
using Newtonsoft.Json;
using System.IO;
using DevoxTestTask.Services.Interfaces;

namespace DevoxTestTask.Services
{
    public class ProjectsService:IProjectsService
    {
        private readonly EmployeesActivityContext context;
        public ProjectsService(EmployeesActivityContext context)
        {
            this.context = context;
        }

        public IEnumerable<Project> GetAllProjects()
        {            
            var projects = context.Projects;

            return projects;
        }
        public void AddProject(Project project)
        {
           
            context.Projects.Add(project);
        }

        public void UpdateProject(Project project)
        {
        }

        public void DeleteProject(int id)
        {

        }

        private void SaveChanges()
        {
            context.SaveChanges();
        }



    }
}
