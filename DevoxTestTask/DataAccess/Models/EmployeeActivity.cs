using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevoxTestTask.DataAccess.Models
{
    public class EmployeeActivity
    {
        public int Id { get; set; }
        public Employee Employee { get; set; }
        public Role Role { get; set; }
        public ActivityType ActivityType { get; set; }
        public Project Project { get; set; }
        public TimeSpan Hours { get; set; }
    }
}
