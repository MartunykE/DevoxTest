using DevoxTestTask.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevoxTestTask.Services.Interfaces
{
    public interface IEmployeeService
    {
        IEnumerable<Employee> GetAllEmployees();
        Employee GetEmployee(int employeeId);
        Task<int> CreateEmployee(Employee employee);
        Task UpdateEmployee(Employee employee);
        Task DeleteEmployee(int employeeId);
        void AddActivity(int employeeId, EmployeeActivity employeeActivity);
        IEnumerable<EmployeeActivity> GetAllEmployeeActivities(int employeeId);
        IEnumerable<EmployeeActivity> GetEmployeeActivitiyPerDay(int employeeId, DateTime date);
        IEnumerable<EmployeeActivity> GetEmployeeActivitiePerWeek(int employeeId, int weekNumber);
    }
}
