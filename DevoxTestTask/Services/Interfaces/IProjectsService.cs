using DevoxTestTask.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevoxTestTask.Services.Interfaces
{
    public interface IProjectsService
    {
        IEnumerable<Project> GetAllProjects();
        void AddProject(Project project);
    }
}
