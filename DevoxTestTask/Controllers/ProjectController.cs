using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevoxTestTask.DataAccess.Models;
using DevoxTestTask.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DevoxTestTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        IProjectsService projectsService;
        public ProjectController(IProjectsService projectsService)
        {
            this.projectsService = projectsService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var projects = projectsService.GetAllProjects();
            if (projects == null)
            {
                return NoContent();
            }
            return Ok(projects);
        }

        [HttpPost]
        public void AddProject(Project project)
        {
            projectsService.AddProject(project);
        }
    }
}