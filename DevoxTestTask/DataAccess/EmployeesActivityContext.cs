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
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EmployeeActivity>().HasKey(p => new { p.ProjectId, p.EmployeeId });

            modelBuilder.Entity<EmployeeActivity>()
            .HasOne(p => p.Employee)
            .WithMany(p => p.EmployeeActivites)
            .HasForeignKey(p => p.EmployeeId);

            modelBuilder.Entity<EmployeeActivity>()
            .HasOne(p => p.Project)
            .WithMany(p => p.EmployeeActivites)
            .HasForeignKey(p => p.ProjectId);



            modelBuilder.Entity<Project>().HasData(
                new Project[]
                {
                    new Project{Id = 1, Name = "Project 1", StartDate = DateTime.Now},
                    new Project{Id = 2, Name = "Project 2",  StartDate = DateTime.Now.AddDays(-145)},
                    new Project{Id = 3, Name = "Project 3", StartDate = DateTime.Now.AddDays(-23)},
                    new Project{Id = 4, Name = "Project 4",  StartDate = DateTime.Now.AddMonths(-2)}
                }
                );
            modelBuilder.Entity<Employee>().HasData(
                new Employee[]
                {
                    new Employee {Id = 1, Name = "Jhon"},
                    new Employee {Id = 2, Name = "David"},
                    new Employee {Id = 3, Name = "Mary"},
                    new Employee {Id = 4, Name = "Anna"}
                });
        }
    }
}
