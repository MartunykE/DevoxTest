using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevoxTestTask.DataAccess.Models;
using DevoxTestTask.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DevoxTestTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        IEmployeeService employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            this.employeeService = employeeService;
        }

        [HttpGet]
        public IActionResult GetAllEmployees()
        {
            var employees = employeeService.GetAllEmployees();
            if (employees == null)
            {
                return NoContent();
            }
            return Ok(employees);
        }

        [HttpGet("{id}")]
        public IActionResult GetEmployee(int id)
        {
            var employee = employeeService.GetEmployee(id);
            if (employee == null)
            {
                return NoContent();
            }
            return Ok(employee);
        }

        [HttpGet("{id}/Projects")]
        public IActionResult GetAllEmpoyeeProjects(int id)
        {
            var employeeActivities = employeeService.GetEmployeeActivities(id);
            if (employeeActivities == null)
            {
                return NoContent();
            }
            return Ok(employeeActivities);
        }

        [HttpPost]
        public async Task<IActionResult> CreateEmployee(Employee employee)
        {
            if (ModelState.IsValid)
            {
                var createdEmployeeId = await employeeService.CreateEmployee(employee);

                return Created($"{Request.Path}/{createdEmployeeId}", employee);
            }
            return BadRequest();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEmployee(int id, Employee employee)
        {
            //Todo: Handle exception
            if (ModelState.IsValid)
            {
                employee.Id = id;
                await employeeService.UpdateEmployee(employee);
                return Ok();
            }
            return BadRequest();
        }

        [HttpPut("{id}/AddActivity")]
        public IActionResult AddActivity(int id, EmployeeActivity employeeActivity)
        {
            if (ModelState.IsValid)
            {
                employeeService.AddActivity(id, employeeActivity);
                return Ok();
            }
            return BadRequest();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            await employeeService.DeleteEmployee(id);
            return Ok();
        }
    }
}
