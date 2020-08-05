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
        public IActionResult GetAllProjects()
        {
            var projects = projectsService.GetAllProjects();
            if (projects == null)
            {
                return NoContent();
            }
            return Ok(projects);
        }

        [HttpGet("{id}")]
        public IActionResult GetProject(int id)
        {
            var project = projectsService.GetProject(id);
            if (project == null)
            {
                return NoContent();
            }
            return Ok(project);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProject(Project project)
        {
            if (ModelState.IsValid)
            {
                var createdProjectId = await projectsService.CreateProject(project);

                return Created($"{Request.Path}/{createdProjectId}", project);
            }
            return BadRequest();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProject(int id, Project project)
        {
            if (ModelState.IsValid)
            {
                project.Id = id;
                await projectsService.UpdateProject(project);
                return Ok();
            }
            return BadRequest();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProject(int id)
        {
            await projectsService.DeleteProject(id);
            return Ok();
        }
    }
}