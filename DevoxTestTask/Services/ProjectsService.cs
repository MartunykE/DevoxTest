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
    public class ProjectsService : IProjectsService
    {
        private readonly EmployeesActivityContext context;
        public ProjectsService(EmployeesActivityContext context)
        {
            this.context = context;
        }
        public Project GetProject(int id)
        {
            Project project = context.Projects.Find(id);
            return project;
        }
        public IEnumerable<Project> GetAllProjects()
        {
            var projects = context.Projects;
            return projects;
        }
        public async Task<int> CreateProject(Project project)
        {
            context.Projects.Add(project);
            await context.SaveChangesAsync();

            return project.Id;
        }

        public async Task UpdateProject(Project project)
        {
            context.Update(project);
            await context.SaveChangesAsync();
        }

        public async Task DeleteProject(int id)
        {
            var project =  context.Projects.Find(id);
            context.Projects.Remove(project);

            await context.SaveChangesAsync();
        }

        
    }
}
