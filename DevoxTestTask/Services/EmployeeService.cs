using DevoxTestTask.DataAccess;
using DevoxTestTask.DataAccess.Models;
using DevoxTestTask.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevoxTestTask.Services
{
    public class EmployeeService : IEmployeeService
    {
        EmployeesActivityContext context;
        public EmployeeService(EmployeesActivityContext context)
        {
            this.context = context;
        }

        public IEnumerable<Employee> GetAllEmployees()
        {
            var employees = context.Employees;
            return employees;
        }

        public Employee GetEmployee(int id)
        {
            Employee project = context.Employees.Find(id);
            return project;
        }

        public async Task<int> CreateEmployee(Employee employee)
        {
            context.Employees.Add(employee);
            await context.SaveChangesAsync();

            return employee.Id;
        }

        public async Task UpdateEmployee(Employee employee)
        {
            context.Update(employee);
            await context.SaveChangesAsync();
        }
        public async Task DeleteEmployee(int id)
        {
            var employee = context.Employees.Find(id);
            context.Employees.Remove(employee);

            await context.SaveChangesAsync();
        }

      
    }
}
