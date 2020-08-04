using DevoxTestTask.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevoxTestTask.DataAccess
{
    public class EmployeesActivityContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<ActivityType> ActivityTypes { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<EmployeeActivity> EmployeeActivity { get; set; }

        public EmployeesActivityContext(DbContextOptions<EmployeesActivityContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        
      
    }
}
