using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DevoxTestTask.DataAccess.Models
{
    public class EmployeeActivity
    {
        public int Id { get; set; }
        [Required]
        public Employee Employee { get; set; }
        [Required]
        public Role Role { get; set; }
        [Required]
        public ActivityType ActivityType { get; set; }
        [Required]
        public Project Project { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public TimeSpan Hours { get; set; }
    }
}
