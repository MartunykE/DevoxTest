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
        Project GetProject(int id);
        Task<int> CreateProject(Project project);
        Task UpdateProject(Project project);
        Task DeleteProject(int id);
    }
}
