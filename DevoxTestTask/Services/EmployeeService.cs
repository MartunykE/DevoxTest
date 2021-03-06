﻿using DevoxTestTask.DataAccess;
using DevoxTestTask.DataAccess.Models;
using DevoxTestTask.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Globalization;
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

        public Employee GetEmployee(int employeeId)
        {
            var employee = context.Employees
                .Include(p => p.EmployeeActivites)
                .ThenInclude(p => p.Project)
                .Include(p => p.EmployeeActivites)
                .ThenInclude(p => p.Role)
                .Include(p => p.EmployeeActivites)
                .ThenInclude(p => p.ActivityType)
                .Where(e => e.Id == employeeId)
                .FirstOrDefault();

            return employee;
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
        public async Task DeleteEmployee(int employeeId)
        {
            var employee = context.Employees.Find(employeeId);
            context.Employees.Remove(employee);

            await context.SaveChangesAsync();
        }

        public IEnumerable<EmployeeActivity> GetAllEmployeeActivities(int employeeId)
        {
            return context.Employees.Find(employeeId).EmployeeActivites;
        }

        public void AddActivity(int employeeId, EmployeeActivity employeeActivity)
        {
            employeeActivity.EmployeeId = employeeActivity.Employee.Id;
            employeeActivity.ProjectId = employeeActivity.Project.Id;
            var employee = context.Employees.Find(employeeId);
            if (employee.EmployeeActivites == null)
            {
                employee.EmployeeActivites = new List<EmployeeActivity>();
            }
            employee.EmployeeActivites.Add(employeeActivity);
            context.SaveChanges();
        }

        public IEnumerable<EmployeeActivity> GetEmployeeActivitiyPerDay(int employeeId, DateTime date)
        {
            return GetEmployeeActivitiyPerPeriod(employeeId, activity => activity.Date.Date == date.Date);
        }

        public IEnumerable<EmployeeActivity> GetEmployeeActivitiePerWeek(int employeeId, int weekNumber)
        {
            var firstDayOfWeek = ISOWeek.ToDateTime(DateTime.Now.Year, weekNumber, DayOfWeek.Monday);
            var lastDayOfWeek = ISOWeek.ToDateTime(DateTime.Now.Year, weekNumber, DayOfWeek.Sunday);
            var r = GetEmployeeActivitiyPerPeriod(employeeId, a => a.Date.Date >= firstDayOfWeek.Date && a.Date.Date <= lastDayOfWeek.Date.Date);
            return r;
        }
        private IEnumerable<EmployeeActivity> GetEmployeeActivitiyPerPeriod(int employeeId, Func<EmployeeActivity, bool> periodCondition)
        {
            var activity = context.EmployeeActivity
                .Include(a => a.Role)
                .Include(a => a.ActivityType)
                .Include(a => a.Project)
                .Where(e => e.EmployeeId == employeeId)
                .Where(periodCondition).ToList();

            return activity;
        }

    }
}
